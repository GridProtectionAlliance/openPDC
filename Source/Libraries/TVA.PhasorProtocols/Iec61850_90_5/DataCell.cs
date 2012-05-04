//******************************************************************************************************
//  DataCell.cs - Gbtc
//
//  Copyright © 2012, Grid Protection Alliance.  All Rights Reserved.
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
//  04/19/2012 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TVA.PhasorProtocols.Iec61850_90_5
{
    /// <summary>
    /// Represents the IEC 61850-90-5 implementation of a <see cref="IDataCell"/> that can be sent or received.
    /// </summary>
    [Serializable()]
    public class DataCell : DataCellBase
    {
        #region [ Members ]

        // Fields
        private string m_msvID;
        private string m_dataSet;
        private ushort m_sampleCount;
        private uint m_configurationRevision;
        private byte m_sampleSynchronization;
        private ushort m_sampleRate;
        private ConfigurationFrame m_configuration;
        private int m_parsedBodyLength;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="DataCell"/>.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="IDataFrame"/> of this <see cref="DataCell"/>.</param>
        /// <param name="configurationCell">The <see cref="IConfigurationCell"/> associated with this <see cref="DataCell"/>.</param>
        public DataCell(IDataFrame parent, IConfigurationCell configurationCell)
            : base(parent, configurationCell, 0x0000, Common.MaximumPhasorValues, Common.MaximumAnalogValues, Common.MaximumDigitalValues)
        {
            // Define new parsing state which defines constructors for key data values
            State = new DataCellParsingState(
                configurationCell,
                Iec61850_90_5.PhasorValue.CreateNewValue,
                Iec61850_90_5.FrequencyValue.CreateNewValue,
                Iec61850_90_5.AnalogValue.CreateNewValue,
                Iec61850_90_5.DigitalValue.CreateNewValue);
        }

        /// <summary>
        /// Creates a new <see cref="DataCell"/> from specified parameters.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="DataFrame"/> of this <see cref="DataCell"/>.</param>
        /// <param name="configurationCell">The <see cref="ConfigurationCell"/> associated with this <see cref="DataCell"/>.</param>
        /// <param name="addEmptyValues">If <c>true</c>, adds empty values for each defined configuration cell definition.</param>
        public DataCell(DataFrame parent, ConfigurationCell configurationCell, bool addEmptyValues)
            : this(parent, configurationCell)
        {
            if (addEmptyValues)
            {
                int x;

                // Define needed phasor values
                for (x = 0; x < configurationCell.PhasorDefinitions.Count; x++)
                {
                    PhasorValues.Add(new PhasorValue(this, configurationCell.PhasorDefinitions[x]));
                }

                // Define a frequency and df/dt
                FrequencyValue = new FrequencyValue(this, configurationCell.FrequencyDefinition);

                // Define any analog values
                for (x = 0; x < configurationCell.AnalogDefinitions.Count; x++)
                {
                    AnalogValues.Add(new AnalogValue(this, configurationCell.AnalogDefinitions[x]));
                }

                // Define any digital values
                for (x = 0; x < configurationCell.DigitalDefinitions.Count; x++)
                {
                    DigitalValues.Add(new DigitalValue(this, configurationCell.DigitalDefinitions[x]));
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="DataCell"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected DataCell(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Deserialize data cell elements...
            m_msvID = info.GetString("msvID");
            m_dataSet = info.GetString("dataSet");
            m_sampleCount = info.GetUInt16("sampleCount");
            m_configurationRevision = info.GetUInt32("configurationRevision");
            m_sampleSynchronization = info.GetByte("sampleSynchronization");
            m_sampleRate = info.GetUInt16("sampleRate");
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the reference to parent <see cref="DataFrame"/> of this <see cref="DataCell"/>.
        /// </summary>
        public new DataFrame Parent
        {
            get
            {
                return base.Parent as DataFrame;
            }
            set
            {
                base.Parent = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ConfigurationCell"/> associated with this <see cref="DataCell"/>.
        /// </summary>
        public new ConfigurationCell ConfigurationCell
        {
            get
            {
                return base.ConfigurationCell as ConfigurationCell;
            }
            set
            {
                base.ConfigurationCell = value;
            }
        }

        /// <summary>
        /// Gets or sets status flags for this <see cref="DataCell"/>.
        /// </summary>
        public new StatusFlags StatusFlags
        {
            get
            {
                return (StatusFlags)(base.StatusFlags & ~(ushort)(StatusFlags.UnlockedTimeMask | StatusFlags.TriggerReasonMask));
            }
            set
            {
                base.StatusFlags = (ushort)((base.StatusFlags & (ushort)(StatusFlags.UnlockedTimeMask | StatusFlags.TriggerReasonMask)) | (ushort)value);
            }
        }

        /// <summary>
        /// Gets or sets unlocked time of this <see cref="DataCell"/>.
        /// </summary>
        public UnlockedTime UnlockedTime
        {
            get
            {
                return (UnlockedTime)(base.StatusFlags & (ushort)StatusFlags.UnlockedTimeMask);
            }
            set
            {
                base.StatusFlags = (ushort)((base.StatusFlags & ~(ushort)StatusFlags.UnlockedTimeMask) | (ushort)value);
                SynchronizationIsValid = (value == Iec61850_90_5.UnlockedTime.SyncLocked);
            }
        }

        /// <summary>
        /// Gets or sets trigger reason of this <see cref="DataCell"/>.
        /// </summary>
        public TriggerReason TriggerReason
        {
            get
            {
                return (TriggerReason)(base.StatusFlags & (short)StatusFlags.TriggerReasonMask);
            }
            set
            {
                base.StatusFlags = (ushort)((base.StatusFlags & ~(short)StatusFlags.TriggerReasonMask) | (ushort)value);
                DeviceTriggerDetected = (value != Iec61850_90_5.TriggerReason.Manual);
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if data of this <see cref="DataCell"/> is valid.
        /// </summary>
        public override bool DataIsValid
        {
            get
            {
                // TODO: Should data be considered invalid when signature check fails? On my test device this would always be invalid since SHA is fixed...
                return (StatusFlags & Iec61850_90_5.StatusFlags.DataIsValid) == 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DataIsValid;
                else
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DataIsValid;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if timestamp of this <see cref="DataCell"/> is valid based on GPS lock.
        /// </summary>
        public override bool SynchronizationIsValid
        {
            get
            {
                // TODO: Not sure which synchronization flag should take priority here - so using both for now...
                return (StatusFlags & Iec61850_90_5.StatusFlags.DeviceSynchronizationError) == 0 && m_sampleSynchronization > 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DeviceSynchronizationError;
                else
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DeviceSynchronizationError;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="PhasorProtocols.DataSortingType"/> of this <see cref="DataCell"/>.
        /// </summary>
        public override DataSortingType DataSortingType
        {
            get
            {
                return (((StatusFlags & Iec61850_90_5.StatusFlags.DataSortingType) == 0) ? PhasorProtocols.DataSortingType.ByTimestamp : PhasorProtocols.DataSortingType.ByArrival);
            }
            set
            {
                if (value == PhasorProtocols.DataSortingType.ByTimestamp)
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DataSortingType;
                else
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DataSortingType;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if source device of this <see cref="DataCell"/> is reporting an error.
        /// </summary>
        public override bool DeviceError
        {
            get
            {
                return (StatusFlags & Iec61850_90_5.StatusFlags.DeviceError) > 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DeviceError;
                else
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DeviceError;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if device trigger is detected for this <see cref="DataCell"/>.
        /// </summary>
        public bool DeviceTriggerDetected
        {
            get
            {
                return (StatusFlags & Iec61850_90_5.StatusFlags.DeviceTriggerDetected) > 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DeviceTriggerDetected;
                else
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DeviceTriggerDetected;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if configuration change was detected for this <see cref="DataCell"/>.
        /// </summary>
        public bool ConfigurationChangeDetected
        {
            get
            {
                return (StatusFlags & Iec61850_90_5.StatusFlags.ConfigurationChanged) > 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.ConfigurationChanged;
                else
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.ConfigurationChanged;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for the <see cref="ChannelFrameBase{T}"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                baseAttributes.Add("MSVID", m_msvID);
                baseAttributes.Add("Dataset", m_dataSet);
                baseAttributes.Add("Sample Count", m_sampleCount.ToString());
                baseAttributes.Add("Configuration Revision", m_configurationRevision.ToString());
                baseAttributes.Add("Sample Synchronization", m_sampleSynchronization + ": " + (m_sampleSynchronization == 0 ? "Not Synchronized" : "Synchronized"));
                baseAttributes.Add("Sample Rate", m_sampleRate.ToString());
                baseAttributes.Add("Unlocked Time", (int)UnlockedTime + ": " + UnlockedTime);
                baseAttributes.Add("Device Trigger Detected", DeviceTriggerDetected.ToString());
                baseAttributes.Add("Trigger Reason", (int)TriggerReason + ": " + TriggerReason);
                baseAttributes.Add("Configuration Change Detected", ConfigurationChangeDetected.ToString());

                return baseAttributes;
            }
        }

        /// <summary>
        /// Gets the length of the body.
        /// </summary>
        protected override int BodyLength
        {
            get
            {
                if (m_parsedBodyLength == 0)
                    return base.BodyLength;

                return m_parsedBodyLength;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Parses the binary body image.
        /// </summary>
        /// <param name="buffer">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="buffer"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="buffer"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        protected override int ParseBodyImage(byte[] buffer, int startIndex, int length)
        {
            const decimal timebase = 16777216;
            CommonFrameHeader header = Parent.CommonHeader;
            int tagLength, index = startIndex;

            // Get reference to configuration frame, if available
            m_configuration = Parent.ConfigurationFrame;

            // Parse each ASDU in incoming frame (e.g, DataCell(t-2), DataCell(t-1), DataCell(t))
            for (int i = 0; i < header.AsduCount; i++)
            {
                // Handle redundant ASDU - last one parsed will be newest and exposed normally
                if (i > 0)
                {
                    if (header.ParseRedundantASDUs)
                    {
                        // Create a new data frame to hold redundant ASDU data
                        DataFrame dataFrame = new DataFrame
                        {
                            ConfigurationFrame = m_configuration,
                            CommonHeader = header
                        };

                        // Add a copy of the current data cell to the new frame 
                        dataFrame.Cells.Add(this.MemberwiseClone() as DataCell);

                        // Publish new data frame with redundant ASDU data
                        header.PublishFrame(dataFrame);
                    }

                    // Clear any existing ADSU values from this data cell
                    PhasorValues.Clear();
                    AnalogValues.Clear();
                    DigitalValues.Clear();
                }

                // Validate ASDU sequence tag exists and skip past it
                buffer.ValidateTag(SampledValueTag.AsduSequence, ref index);

                // Parse MSVID value
                m_msvID = buffer.ParseStringTag(SampledValueTag.MsvID, ref index);

                // Parse dataset name
                m_dataSet = buffer.ParseStringTag(SampledValueTag.Dataset, ref index);

                // Parse sample count (for some reason this is coming in as 3 bytes)
                m_sampleCount = buffer.ParseUInt16Tag(SampledValueTag.SmpCnt, ref index);

                // Parse configuration revision (for some reason this is coming in as 5 bytes)
                m_configurationRevision = buffer.ParseUInt32Tag(SampledValueTag.ConfRev, ref index);

                // Parse refresh time
                if ((SampledValueTag)buffer[index] != SampledValueTag.RefrTm)
                    throw new InvalidOperationException("Encountered out-of-sequence or unknown sampled value tag: 0x" + buffer[startIndex].ToString("X").PadLeft(2, '0'));

                index++;
                tagLength = buffer.GetTagLength(ref index);

                if (tagLength < 8)
                    throw new InvalidOperationException(string.Format("Unexpected length for \"{0}\" tag: {1}", SampledValueTag.RefrTm, tagLength));

                uint secondOfCentury = EndianOrder.BigEndian.ToUInt32(buffer, index);
                uint fractionOfSecond = EndianOrder.BigEndian.ToUInt32(buffer, index + 4);
                index += 8;

                // Get whole seconds of timestamp
                long timestamp = (new UnixTimeTag((double)secondOfCentury)).ToDateTime().Ticks;

                // Add fraction seconds of timestamp
                decimal fractionalSeconds = (fractionOfSecond & ~Common.TimeQualityFlagsMask) / (decimal)timebase;
                timestamp += (long)(fractionalSeconds * (decimal)Ticks.PerSecond);

                // Apply parsed timestamp to common header
                header.Timestamp = timestamp;
                header.TimeQualityFlags = (TimeQualityFlags)(fractionOfSecond & Common.TimeQualityFlagsMask);

                // Parse sample synchronization state
                m_sampleSynchronization = buffer.ParseByteTag(SampledValueTag.SmpSynch, ref index);

                // Parse optional sample rate
                if ((SampledValueTag)buffer[index] == SampledValueTag.SmpRate)
                    m_sampleRate = buffer.ParseUInt16Tag(SampledValueTag.SmpRate, ref index);

                // Validate that next tag is for sample values
                if ((SampledValueTag)buffer[index] != SampledValueTag.Samples)
                    throw new InvalidOperationException("Encountered out-of-sequence or unknown sampled value tag: 0x" + buffer[startIndex].ToString("X").PadLeft(2, '0'));

                index++;
                tagLength = buffer.GetTagLength(ref index);

                // Attempt to derive a configuration if none is defined
                if ((object)m_configuration == null)
                {
                    // If requested, attempt to load configuration from an associated ETR file
                    if (header.UseETRConfiguration)
                        ParseETRConfiguration();

                    // If we still have no configuration, see if a "guess" is requested
                    if ((object)m_configuration == null && header.GuessConfiguration)
                        GuessAtConfiguration();
                }

                if ((object)m_configuration == null)
                {
                    // If the configuration is still unavailable, skip past sample values - don't know the details otherwise
                    index += tagLength;
                }
                else
                {
                    // Validate that sample size matches current configuration
                    if (tagLength != m_configuration.GetCalculatedSampleLength())
                        throw new InvalidOperationException("Configuration does match data sample size - cannot parse data");

                    // Parse standard synchrophasor sequence
                    index += base.ParseBodyImage(buffer, index, length);
                }

                // Skip past optional sample mod tag, if defined
                if ((SampledValueTag)buffer[startIndex] == SampledValueTag.SmpMod)
                    buffer.ValidateTag(SampledValueTag.SmpMod, ref index);

                // Skip past optional UTC timestamp tag, if defined
                if ((SampledValueTag)buffer[startIndex] == SampledValueTag.UtcTimestamp)
                    buffer.ValidateTag(SampledValueTag.UtcTimestamp, ref index);
            }

            // Get parsed body length
            m_parsedBodyLength = index - startIndex;

            return m_parsedBodyLength;
        }

        // Attempt to parse an associated ETR configuration
        private void ParseETRConfiguration()
        {
            //m_configuration = new ConfigurationFrame();
            //Parent.ConfigurationFrame = m_configuration;
        }

        // Attempt to guess at the configuration
        private void GuessAtConfiguration()
        {
            //m_configuration = new ConfigurationFrame();
            //Parent.ConfigurationFrame = m_configuration;
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Add data cell elements for serialization...
            info.AddValue("msvID", m_msvID);
            info.AddValue("dataSet", m_dataSet);
            info.AddValue("sampleCount", m_sampleCount);
            info.AddValue("configurationRevision", m_configurationRevision);
            info.AddValue("sampleSynchronization", m_sampleSynchronization);
            info.AddValue("sampleRate", m_sampleRate);
        }

        #endregion

        #region [ Static ]

        // Static Methods

        // Delegate handler to create a new IEC 61850-90-5 data cell
        internal static IDataCell CreateNewCell(IChannelFrame parent, IChannelFrameParsingState<IDataCell> state, int index, byte[] buffer, int startIndex, out int parsedLength)
        {
            IDataFrameParsingState parsingState = state as IDataFrameParsingState;
            IConfigurationCell configurationCell = null;

            // With or without an associated configuration, we'll parse the data cell
            if (parsingState != null && parsingState.ConfigurationFrame != null)
                configurationCell = parsingState.ConfigurationFrame.Cells[index];

            DataCell dataCell = new DataCell(parent as IDataFrame, configurationCell);

            parsedLength = dataCell.ParseBinaryImage(buffer, startIndex, 0);

            return dataCell;
        }

        #endregion
    }
}