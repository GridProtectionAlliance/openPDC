//******************************************************************************************************
//  C:\Projects\openPDC\Synchrophasor\Current Version\Source\Libraries\TVA.PhasorProtocols\FrameParserBase.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  02/12/2007 - J. Ritchie Carroll
//       Generated original version of source code.
//  12/16/2008 - J. Ritchie Carroll
//       Converted class to inherit from FrameImageParserBase.
//  08/07/2009 - Josh L. Patterson
//       Edited Comments.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//  05/25/2012 - J. Ritchie Carroll
//       Fixed an issue with publication of the frame buffer image so that when connection tester
//       serializes these frames they will not overlap when parsing large data sets.
//
//******************************************************************************************************

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TVA.Collections;
using TVA.Parsing;

namespace TVA.PhasorProtocols
{
    /// <summary>
    /// Represents a frame parser that defines the basic functionality for a protocol to parse a binary data stream and return the parsed data via events.
    /// </summary>
    /// <remarks>
    /// Frame parsers are implemented as a write-only streams so that data can come from any source.<br/>
    /// See <see cref="FrameImageParserBase{TFrameIdentifier, TCommonFrameHeader}"/> for more detail.
    /// </remarks>
    /// <typeparam name="TFrameIdentifier">Frame type identifier used to distinguish frames.</typeparam>
    public abstract class FrameParserBase<TFrameIdentifier> : FrameImageParserBase<TFrameIdentifier, ISupportFrameImage<TFrameIdentifier>>, IFrameParser
    {
        #region [ Members ]

        // Events

        // Derived classes will typically also expose events to provide instances to the protocol specific final derived channel frames

        /// <summary>
        /// Occurs when a <see cref="IConfigurationFrame"/> has been received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the <see cref="IConfigurationFrame"/> that was received.
        /// </remarks>
        public event EventHandler<EventArgs<IConfigurationFrame>> ReceivedConfigurationFrame;

        /// <summary>
        /// Occurs when a <see cref="IDataFrame"/> has been received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the <see cref="IDataFrame"/> that was received.
        /// </remarks>
        public event EventHandler<EventArgs<IDataFrame>> ReceivedDataFrame;

        /// <summary>
        /// Occurs when a <see cref="IHeaderFrame"/> has been received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the <see cref="IHeaderFrame"/> that was received.
        /// </remarks>
        public event EventHandler<EventArgs<IHeaderFrame>> ReceivedHeaderFrame;

        /// <summary>
        /// Occurs when a <see cref="ICommandFrame"/> has been received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the <see cref="ICommandFrame"/> that was received.
        /// <para>
        /// Command frames are normally sent, not received, but there is nothing that prevents this.
        /// </para>
        /// </remarks>
        public event EventHandler<EventArgs<ICommandFrame>> ReceivedCommandFrame;

        /// <summary>
        /// Occurs when an undetermined <see cref="IChannelFrame"/> has been received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the undetermined <see cref="IChannelFrame"/> that was received.
        /// </remarks>
        public event EventHandler<EventArgs<IChannelFrame>> ReceivedUndeterminedFrame;

        /// <summary>
        /// Occurs when a frame buffer image has been received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T1,T2,T3,T4}.Argument1"/> is the <see cref="FundamentalFrameType"/> of the frame buffer image that was received.<br/>
        /// <see cref="EventArgs{T1,T2,T3,T4}.Argument2"/> is the buffer that contains the frame image that was received.<br/>
        /// <see cref="EventArgs{T1,T2,T3,T4}.Argument3"/> is the offset into the buffer that contains the frame image that was received.<br/>
        /// <see cref="EventArgs{T1,T2,T3,T4}.Argument4"/> is the length of data in the buffer that contains the frame image that was received..
        /// </remarks>
        public event EventHandler<EventArgs<FundamentalFrameType, byte[], int, int>> ReceivedFrameBufferImage;

        /// <summary>
        /// Occurs when a device sends a notification that its configuration has changed.
        /// </summary>
        public event EventHandler ConfigurationChanged;

        // Fields
        private ProcessQueue<byte[]> m_bufferQueue;
        private IConnectionParameters m_connectionParameters;
        private BlockingCollection<EventArgs<FundamentalFrameType, byte[], int, int>> m_frameImageQueue;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="FrameParserBase{TypeIndentifier}"/>.
        /// </summary>
        protected FrameParserBase()
        {
            // We attach to base class DataParsed event to automatically redirect and cast channel frames to their specific output events
            base.DataParsed += base_DataParsed;
            base.DuplicateTypeHandlerEncountered += base_DuplicateTypeHandlerEncountered;
            base.OutputTypeNotFound += base_OutputTypeNotFound;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets a flag that allows frame parsing to be executed on a separate thread (i.e., other than communications thread).
        /// </summary>
        /// <remarks>
        /// This is typically only needed when data frames are very large. This change will happen dynamically, even if a connection is active.
        /// </remarks>
        public virtual bool ExecuteParseOnSeparateThread
        {
            get
            {
                return ((object)m_bufferQueue != null);
            }
            set
            {
                // This property allows a dynamic change in state of how to process streaming data
                if (value)
                {
                    if ((object)m_bufferQueue == null)
                    {
                        m_bufferQueue = CreateBufferQueue();
                        m_bufferQueue.ProcessException += m_bufferQueue_ProcessException;
                    }

                    if (Enabled && !m_bufferQueue.Enabled)
                        m_bufferQueue.Start();
                }
                else
                {
                    if ((object)m_bufferQueue != null)
                    {
                        m_bufferQueue.Stop();
                        m_bufferQueue.ProcessException -= m_bufferQueue_ProcessException;
                    }

                    m_bufferQueue = null;
                }
            }
        }

        /// <summary>
        /// Gets the total number of buffers that are currently queued for processing, if any.
        /// </summary>
        public virtual int QueuedBuffers
        {
            get
            {
                if ((object)m_bufferQueue == null)
                    return 0;
                else
                    return m_bufferQueue.Count;
            }
        }

        /// <summary>
        /// Gets the number of redundant frames in each packet.
        /// </summary>
        /// <remarks>
        /// <para>This value is used when calculating statistics. It is assumed that for each
        /// frame that is received, that frame will be included in the next <c>n</c>
        /// packets, where <c>n</c> is the number of redundant frames per packet.</para>
        /// 
        /// <para>This base class returns 0, as most protocols do not support redundant frames.</para>
        /// </remarks>
        public virtual int RedundantFramesPerPacket
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets current <see cref="IConfigurationFrame"/> used for parsing <see cref="IDataFrame"/>'s encountered in the data stream from a device.
        /// </summary>
        /// <remarks>
        /// If a <see cref="IConfigurationFrame"/> has been parsed, this will return a reference to the parsed frame.  Consumer can manually assign a
        /// <see cref="IConfigurationFrame"/> to start parsing data if one has not been encountered in the stream.
        /// </remarks>
        public abstract IConfigurationFrame ConfigurationFrame
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets any connection specific <see cref="IConnectionParameters"/> that may be needed for parsing.
        /// </summary>
        public virtual IConnectionParameters ConnectionParameters
        {
            get
            {
                return m_connectionParameters;
            }
            set
            {
                m_connectionParameters = value;
            }
        }

        /// <summary>
        /// Gets current descriptive status of the <see cref="FrameParserBase{TypeIndentifier}"/>.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                status.Append(base.Status);
                status.Append("     Received config frame: ");
                status.Append(ConfigurationFrame == null ? "No" : "Yes");
                status.AppendLine();

                if ((object)ConfigurationFrame != null)
                {
                    status.Append("   Devices in config frame: ");
                    status.Append(ConfigurationFrame.Cells.Count);
                    status.Append(" total - ");
                    status.AppendLine();

                    foreach (IConfigurationCell cell in ConfigurationFrame.Cells)
                    {
                        status.AppendFormat("               ({0:00000}) {1}{2}\r\n", cell.IDCode, cell.StationName.PadRight(16), string.IsNullOrEmpty(cell.IDLabel) ? "" : string.Format(" [{0}]", cell.IDLabel));
                    }

                    status.Append("     Configured frame rate: ");
                    status.Append(ConfigurationFrame.FrameRate);
                    status.AppendLine();
                }

                status.Append("  Parsing execution source: ");

                if ((object)m_bufferQueue == null)
                {
                    status.Append("Communications thread");
                    status.AppendLine();
                }
                else
                {
                    status.Append("Independent thread using queued data");
                    status.AppendLine();
                    status.Append(m_bufferQueue.Status);
                }

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="FrameParserBase{TypeIndentifier}"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if ((object)m_bufferQueue != null)
                        {
                            m_bufferQueue.ProcessException -= m_bufferQueue_ProcessException;
                            m_bufferQueue.Dispose();
                        }
                        m_bufferQueue = null;

                        if ((object)m_frameImageQueue != null)
                            m_frameImageQueue.Dispose();

                        m_frameImageQueue = null;

                        // Detach from base class events
                        base.DataParsed -= base_DataParsed;
                        base.DuplicateTypeHandlerEncountered -= base_DuplicateTypeHandlerEncountered;
                        base.OutputTypeNotFound -= base_OutputTypeNotFound;
                    }
                }
                finally
                {
                    m_disposed = true;          // Prevent duplicate dispose.
                    base.Dispose(disposing);    // Call base class Dispose().
                }
            }
        }

        /// <summary>
        /// Starts the frame parser given the specified type implementations.
        /// </summary>
        /// <param name="implementations">An implementation type paramater.</param>
        public override void Start(IEnumerable<Type> implementations)
        {
            base.Start(implementations);

            if ((object)m_bufferQueue != null)
                m_bufferQueue.Start();

            // Restart frame image queue processing if consumer has attached to frame buffer image event
            if ((object)m_frameImageQueue != null)
                (new Thread(ProcessFrameImageQueue)).Start();
        }

        /// <summary>
        /// Stops the frame parser.
        /// </summary>
        public override void Stop()
        {
            base.Stop();

            if ((object)m_bufferQueue != null)
                m_bufferQueue.Stop();
        }

        /// <summary>
        /// Writes a sequence of bytes onto the stream for parsing.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            if ((object)m_bufferQueue == null)
            {
                // Directly parse frame using calling thread (typically communications thread)
                base.Write(buffer, offset, count);
            }
            else
            {
                // Queue up received data buffer for real-time parsing and return to data collection as quickly as possible...
                m_bufferQueue.Add(buffer.BlockCopy(offset, count));
            }
        }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be parsed immediately.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is only relevant when <see cref="ExecuteParseOnSeparateThread"/> is true; otherwise this method has no effect.
        /// </para>
        /// <para>
        /// If the user has called <see cref="Start"/> method, this method will process all remaining buffers on the calling thread
        /// until all queued buffers have been parsed - the <see cref="FrameParserBase{TFrameIdentifier}"/> will then be automatically
        /// stopped. This method is typically called on shutdown to make sure any remaining queued buffers get parsed before the class
        /// instance is destructed.
        /// </para>
        /// <para>
        /// It is possible for items to be queued while the flush is executing. The flush will continue to parse buffers as quickly
        /// as possible until the internal buffer queue is empty. Unless the user stops queueing data to be parsed (i.e. calling the
        /// <see cref="Write"/> method), the flush call may never return (not a happy situtation on shutdown).
        /// </para>
        /// <para>
        /// The <see cref="FrameParserBase{TFrameIdentifier}"/> does not clear queue prior to destruction. If the user fails to call
        /// this method before the class is destructed, there may be data that remains unparsed in the internal buffer.
        /// </para>
        /// </remarks>
        public override void Flush()
        {
            if ((object)m_bufferQueue != null)
                m_bufferQueue.Flush();
        }

        /// <summary>
        /// Raises the <see cref="ReceivedConfigurationFrame"/> event.
        /// </summary>
        /// <param name="frame"><see cref="IConfigurationFrame"/> to send to <see cref="ReceivedConfigurationFrame"/> event.</param>
        protected virtual void OnReceivedConfigurationFrame(IConfigurationFrame frame)
        {
            if ((object)ReceivedConfigurationFrame != null)
                ReceivedConfigurationFrame(this, new EventArgs<IConfigurationFrame>(frame));
        }

        /// <summary>
        /// Raises the <see cref="ReceivedDataFrame"/> event.
        /// </summary>
        /// <param name="frame"><see cref="IDataFrame"/> to send to <see cref="ReceivedDataFrame"/> event.</param>
        protected virtual void OnReceivedDataFrame(IDataFrame frame)
        {
            if ((object)ReceivedDataFrame != null)
                ReceivedDataFrame(this, new EventArgs<IDataFrame>(frame));
        }

        /// <summary>
        /// Raises the <see cref="ReceivedHeaderFrame"/> event.
        /// </summary>
        /// <param name="frame"><see cref="IHeaderFrame"/> to send to <see cref="ReceivedHeaderFrame"/> event.</param>
        protected virtual void OnReceivedHeaderFrame(IHeaderFrame frame)
        {
            if ((object)ReceivedHeaderFrame != null)
                ReceivedHeaderFrame(this, new EventArgs<IHeaderFrame>(frame));
        }

        /// <summary>
        /// Raises the <see cref="ReceivedCommandFrame"/> event.
        /// </summary>
        /// <param name="frame"><see cref="ICommandFrame"/> to send to <see cref="ReceivedCommandFrame"/> event.</param>
        protected virtual void OnReceivedCommandFrame(ICommandFrame frame)
        {
            if ((object)ReceivedCommandFrame != null)
                ReceivedCommandFrame(this, new EventArgs<ICommandFrame>(frame));
        }

        /// <summary>
        /// Raises the <see cref="ReceivedUndeterminedFrame"/> event.
        /// </summary>
        /// <param name="frame"><see cref="IChannelFrame"/> to send to <see cref="ReceivedUndeterminedFrame"/> event.</param>
        protected virtual void OnReceivedUndeterminedFrame(IChannelFrame frame)
        {
            if ((object)ReceivedUndeterminedFrame != null)
                ReceivedUndeterminedFrame(this, new EventArgs<IChannelFrame>(frame));
        }

        /// <summary>
        /// Raises the <see cref="ReceivedFrameBufferImage"/> event.
        /// </summary>
        /// <param name="frameType"><see cref="FundamentalFrameType"/> to send to <see cref="ReceivedFrameBufferImage"/> event.</param>
        /// <param name="buffer">Frame buffer image to send to <see cref="ReceivedFrameBufferImage"/> event.</param>
        /// <param name="offset">Offset into frame buffer image to send to <see cref="ReceivedFrameBufferImage"/> event.</param>
        /// <param name="length">Length of data in frame buffer image to send to <see cref="ReceivedFrameBufferImage"/> event.</param>
        protected virtual void OnReceivedFrameBufferImage(FundamentalFrameType frameType, byte[] buffer, int offset, int length)
        {
            // Since this event is called from an async socket operation, these events can be processed simultaneously, especially
            // when the consuming event may take time to process this data (e.g., writing the frame to a capture file for replay),
            // so we queue these events up for serial processing
            if ((object)ReceivedFrameBufferImage != null)
            {
                // If a consumer is subscribing to this event, make sure frame image queue exists
                if ((object)m_frameImageQueue == null)
                {
                    m_frameImageQueue = new BlockingCollection<EventArgs<FundamentalFrameType, byte[], int, int>>();
                    (new Thread(ProcessFrameImageQueue)).Start();
                }

                m_frameImageQueue.Add(new EventArgs<FundamentalFrameType, byte[], int, int>(frameType, buffer, offset, length));
            }
        }

        // Process elements in frame image queue
        private void ProcessFrameImageQueue()
        {
            while (Enabled)
            {
                try
                {
                    // Expose next frame buffer image
                    ReceivedFrameBufferImage(this, m_frameImageQueue.Take());
                }
                catch (Exception ex)
                {
                    OnParsingException(ex);
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="ConfigurationChanged"/> event.
        /// </summary>
        protected virtual void OnConfigurationChanged()
        {
            if ((object)ConfigurationChanged != null)
                ConfigurationChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Casts the parsed <see cref="IChannelFrame"/> to its specific implementation (i.e., <see cref="IDataFrame"/>, <see cref="IConfigurationFrame"/>, <see cref="ICommandFrame"/> or <see cref="IHeaderFrame"/>).
        /// </summary>
        /// <param name="frame"><see cref="IChannelFrame"/> that was parsed by <see cref="FrameImageParserBase{TTypeIdentifier,TOutputType}"/> that implements protocol specific common frame header interface.</param>
        protected virtual void OnReceivedChannelFrame(IChannelFrame frame)
        {
            if ((object)frame != null)
            {
                IDataFrame dataFrame = frame as IDataFrame;

                if ((object)dataFrame != null)
                {
                    // Frame was a data frame
                    OnReceivedDataFrame(dataFrame);
                }
                else
                {
                    IConfigurationFrame configFrame = frame as IConfigurationFrame;

                    if ((object)configFrame != null)
                    {
                        // Frame was a configuration frame
                        OnReceivedConfigurationFrame(configFrame);
                    }
                    else
                    {
                        IHeaderFrame headerFrame = frame as IHeaderFrame;

                        if ((object)headerFrame != null)
                        {
                            // Frame was a header frame
                            OnReceivedHeaderFrame(headerFrame);
                        }
                        else
                        {
                            ICommandFrame commandFrame = frame as ICommandFrame;

                            if ((object)commandFrame != null)
                            {
                                // Frame was a command frame
                                OnReceivedCommandFrame(commandFrame);
                            }
                            else
                            {
                                // Frame type was undetermined
                                OnReceivedUndeterminedFrame(frame);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles unknown frame types.
        /// </summary>
        /// <param name="frameType">Unknown frame ID.</param>
        protected virtual void OnUnknownFrameTypeEncountered(TFrameIdentifier frameType)
        {
            OnParsingException(new InvalidOperationException(string.Format("WARNING: Encountered an undefined frame type identfier \"{0}\". Output was not parsed.", frameType)));
        }

        /// <summary>
        /// Creates the internal buffer queue.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is virtual to allow derived classes to customize the style of processing queue used when consumers
        /// choose to implement an internal buffer queue (i.e., set <see cref="ExecuteParseOnSeparateThread"/> to true).
        /// Default type is a real-time queue with the default settings. When overriding this method, be sure to use the
        /// <see cref="ParseQueuedBuffers"/> method for the <see cref="ProcessQueue{T}"/>) item processing delegate.
        /// </para>
        /// <para>
        /// Note that current design only supports synchronous parsing - consumer overriding this method to return
        /// an asynchronous (i.e., multi-threaded) process queue will need to redesign the processing delegate.
        /// </para>
        /// </remarks>
        /// <returns>New internal buffer processing queue (i.e., a new <see cref="ProcessQueue{T}"/>).</returns>
        protected virtual ProcessQueue<byte[]> CreateBufferQueue()
        {
            return ProcessQueue<byte[]>.CreateRealTimeQueue(ParseQueuedBuffers);
        }

        /// <summary>
        /// This method is used by the internal <see cref="ProcessQueue{T}"/> to process all queued data buffers.
        /// </summary>
        /// <param name="buffers">Queued buffers to process.</param>
        /// <remarks>
        /// This is the item processing delegate to use when overriding the <see cref="CreateBufferQueue"/> method.
        /// </remarks>
        protected void ParseQueuedBuffers(byte[][] buffers)
        {
            // Parse combined data buffers
            byte[] combinedBuffers = buffers.Combine();
            base.Write(combinedBuffers, 0, combinedBuffers.Length);
        }

        // Handles reception of data from base class event "DataParsed"
        private void base_DataParsed(object sender, EventArgs<ISupportFrameImage<TFrameIdentifier>> e)
        {
            // Call overridable channel frame function handler...
            OnReceivedChannelFrame(e.Argument as IChannelFrame);
        }

        // Handles output type not found error from base class event "OutputTypeNotFound"
        private void base_OutputTypeNotFound(object sender, EventArgs<TFrameIdentifier> e)
        {
            // Call overridable output type not found function handler...
            OnUnknownFrameTypeEncountered(e.Argument);
        }

        // Handles duplicate type handler encountered warning from base class event "DuplicateTypeHandlerEncountered"
        private void base_DuplicateTypeHandlerEncountered(object sender, EventArgs<Type, TFrameIdentifier> e)
        {
            // This exception will only occur on start up and is a result of not defining unique frame identifiers for the base types
            OnParsingException(new InvalidOperationException(string.Format("WARNING: Duplicate frame type identfier \"{0}\" encountered for parsing type {1} during initialization. Only the first defined type for this identifier will ever be parsed.", e.Argument2, e.Argument1.FullName)));
        }

        // Handles any exceptions encountered in the buffer queue
        private void m_bufferQueue_ProcessException(object sender, EventArgs<Exception> e)
        {
            OnParsingException(e.Argument);
        }

        #endregion
    }
}