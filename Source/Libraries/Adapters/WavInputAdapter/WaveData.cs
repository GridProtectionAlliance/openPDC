//******************************************************************************************************
//  WaveData.cs - Gbtc
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
//  06/29/2011 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.IO;
using TVA;
using TVA.Media;

namespace WavInputAdapter
{
    /// <summary>
    /// Represents a provider of wave data coming from a stream.
    /// </summary>
    public class WaveData
    {

        #region [ Members ]

        // Fields
        private WaveFormatChunk m_waveFormat;
        private Stream m_waveStream;
        private int m_blockSize;
        private int m_sampleSize;
        private int m_channels;
        private int m_sampleRate;
        private int m_numSamples;
        private TypeCode m_sampleType;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="WaveData"/> class.
        /// </summary>
        /// <param name="preRead">The <see cref="RiffChunk"/> used to determine the number of samples in the stream.</param>
        /// <param name="waveFormat">The format of the wave stream.</param>
        /// <param name="waveStream">The stream containing wave data.</param>
        public WaveData(RiffChunk preRead, WaveFormatChunk waveFormat, Stream waveStream)
        {
            m_waveFormat = waveFormat;
            m_waveStream = waveStream;
            m_blockSize = waveFormat.BlockAlignment;
            m_sampleSize = waveFormat.BitsPerSample / 8;
            m_channels = waveFormat.Channels;
            m_sampleRate = waveFormat.SampleRate;
            m_numSamples = preRead.ChunkSize / m_blockSize;
            m_sampleType = waveFormat.GetSampleTypeCode();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="WaveData"/> class.
        /// </summary>
        /// <param name="waveFormat">The format of the wave stream.</param>
        /// <param name="waveStream">The stream containing wave data.</param>
        public WaveData(WaveFormatChunk waveFormat, Stream waveStream)
            : this(RiffChunk.ReadNext(waveStream), waveFormat, waveStream)
        {
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets the underlying stream providing wave data.
        /// </summary>
        public Stream WaveStream
        {
            get
            {
                return m_waveStream;
            }
        }

        /// <summary>
        /// Gets the number of channels represented by the wave data.
        /// </summary>
        public int Channels
        {
            get
            {
                return m_channels;
            }
        }

        /// <summary>
        /// Gets the sample rate of the wave data.
        /// </summary>
        public int SampleRate
        {
            get
            {
                return m_sampleRate;
            }
        }

        /// <summary>
        /// Gets the total number of samples in the stream before any read operations.
        /// </summary>
        public int NumSamples
        {
            get
            {
                return m_numSamples;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Reads and returns the next sample from the stream.
        /// </summary>
        /// <returns>
        /// The next sample from the stream. The sample is returned as
        /// an array of <see cref="LittleBinaryValue"/>s. Each
        /// LittleBinaryValue represents a different channel.
        /// </returns>
        public LittleBinaryValue[] GetNextSample()
        {
            byte[] buffer = new byte[m_blockSize];
            int bytesRead = m_waveStream.Read(buffer, 0, m_blockSize);
            LittleBinaryValue[] sample;

            if (bytesRead == m_blockSize)
            {
                sample = new LittleBinaryValue[m_channels];

                for (int i = 0; i < m_channels; i++)
                {
                    sample[i] = new LittleBinaryValue(m_sampleType, buffer, i * m_sampleSize, m_sampleSize);
                }

                return sample;
            }

            return null;
        }

        /// <summary>
        /// Closes the underlying stream.
        /// </summary>
        public void Close()
        {
            m_waveStream.Close();
        }

        #endregion

        #region [ Static ]

        // Static Methods

        /// <summary>
        /// Creates a <see cref="WaveData"/> instance created from a WAV file.
        /// </summary>
        /// <param name="fileName">The name of the WAV file.</param>
        /// <returns>The WaveData instance created from a WAV file.</returns>
        public static WaveData GetWaveData(string fileName)
        {
            return GetWaveData(File.OpenRead(fileName));
        }

        /// <summary>
        /// Creates a <see cref="WaveData"/> instance created from a WAV stream.
        /// </summary>
        /// <param name="waveStream">The WAV stream. The data in the stream must include all headers that would be present in a WAV file.</param>
        /// <returns>The WaveData instance created from a WAV stream.</returns>
        public static WaveData GetWaveData(Stream waveStream)
        {
            RiffChunk riffChunk;
            RiffHeaderChunk waveHeader = null;
            WaveFormatChunk waveFormat = null;
            WaveData waveData = null;

            while (waveData == null)
            {
                riffChunk = RiffChunk.ReadNext(waveStream);

                switch (riffChunk.TypeID)
                {
                    case RiffHeaderChunk.RiffTypeID:
                        waveHeader = new RiffHeaderChunk(riffChunk, waveStream, "WAVE");
                        break;
                    case WaveFormatChunk.RiffTypeID:
                        if (waveHeader == null)
                            throw new InvalidDataException("WAVE format section encountered before RIFF header, wave file corrupted");

                        waveFormat = new WaveFormatChunk(riffChunk, waveStream);
                        break;
                    case WaveDataChunk.RiffTypeID:
                        if (waveFormat == null)
                            throw new InvalidDataException("WAVE data section encountered before format section, wave file corrupted");

                        waveData = new WaveData(riffChunk, waveFormat, waveStream);
                        break;
                    default:
                        // Skip unidentified section
                        waveStream.Seek(riffChunk.ChunkSize, SeekOrigin.Current);
                        break;
                }
            }

            return waveData;
        }

        #endregion
    }
}
