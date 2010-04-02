//*******************************************************************************************************
//  DataCellBase.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  01/14/2005 - J. Ritchie Carroll
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//
//*******************************************************************************************************

#region [ TVA Open Source Agreement ]
/*

 THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
 MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
 TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
 ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
 DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
 MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
 ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

 Original Software Designation: openPDC
 Original Software Title: The TVA Open Source Phasor Data Concentrator
 User Registration Requested. Please Visit https://naspi.tva.com/Registration/
 Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

 1. DEFINITIONS

 A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
 that makes a Modification.

 B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
 the use or sale of its Modification alone or when combined with the Subject Software.

 C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
 image, or any other device.

 D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
 another.

 E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
 software separate from the Subject Software that is not governed by the terms of this Agreement.

 F. "Modification" means any alteration of, including addition to or deletion from, the substance or
 structure of either the Original Software or Subject Software, and includes derivative works, as that
 term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
 as part of a Larger Work does not in and of itself constitute a Modification.

 G. "Original Software" means the computer software first released under this Agreement by Government
 Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

 H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
 Contributors.

 I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

 J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

 K. "Sale" means the exchange of the Subject Software for money or equivalent value.

 L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

 M. "Use" means the application or employment of the Subject Software for any purpose.

 2. GRANT OF RIGHTS

 A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
 with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
 non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
 the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Modification

 5. Redistribution

 6. Display

 B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
 respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
 Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
 pertaining to the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Sale

 5. Offer for Sale

 C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
 and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
 such Modification causes the combination to be covered by the Covered Patents. It does not apply to
 any other combinations that include a Modification. 

 D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
 Such sublicense must be under the same terms and conditions of this Agreement.

 3. OBLIGATIONS OF RECIPIENT

 A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
 additions covered under paragraph 3H. 

 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
 must be included with each copy of the Subject Software; and

 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
 Recipient must also make the source code freely available, and must provide with each copy of the
 Subject Software information on how to obtain the source code in a reasonable manner on or through a
 medium customarily used for software exchange.

 B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
 Software:

          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

 C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
 must identify itself as the originator of its Modification in a manner that reasonably allows
 subsequent Recipients to identify the originator of the Modification. In fulfillment of these
 requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
 made and the date of the alterations, identifies Contributor as originator of the alterations, and
 consents to characterization of the alterations as a Modification, for example, by including a
 statement that the Modification is derived, directly or indirectly, from Original Software provided by
 Government Agency. Once consent is granted, it may not thereafter be revoked.

 D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
 been added to the Subject Software, a Recipient may not remove it without the express permission of
 the Contributor who added the notice.

 E. A Recipient may not make any representation in the Subject Software or in any promotional,
 advertising or other material that may be construed as an endorsement by Government Agency or by any
 prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
 advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

 F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
 upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
 following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
 shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
 requested that the Recipient inform Government Agency at the web site provided above how to access the
 Modification.

 G. Each Contributor represents that that its Modification does not violate any existing agreements,
 regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
 conveyed by this Agreement.

 H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
 liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
 however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
 Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
 obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
 Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
 indemnity and/or liability offered by such Recipient.

 I. A Recipient may create a Larger Work by combining Subject Software with separate software not
 governed by the terms of this agreement and distribute the Larger Work as a single product. In such
 case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
 is subject to this Agreement.

 J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
 any goods or technical data from the United States may require some form of export license from the
 U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
 U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
 required, it shall be issued. Nothing granted herein provides any such export license.

 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

 A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
 EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
 SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
 FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
 AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
 RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
 RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
 LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
 "AS IS."

 B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
 AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
 OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
 SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
 SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
 EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
 LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
 EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
 GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
 IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

 5. GENERAL TERMS

 A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
 Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
 thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
 immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
 Software properly granted by the breaching Recipient shall survive any such termination of this
 Agreement.

 B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
 it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

 C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
 including, but not limited to, determining the validity of this Agreement, the meaning of its
 provisions and the rights, obligations and remedies of the parties.

 D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
 parties relating to release of the Subject Software and may not be superseded, modified or amended
 except by further written agreement duly executed by the parties.

 E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
 affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
 Recipient hereby agrees to all terms and conditions herein.

 F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
 representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

*/
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using TVA.Measurements;

namespace TVA.PhasorProtocols
{
    #region [ Enumerations ]

    /// <summary>
    /// Protocol independent common status flags enumeration.
    /// </summary>
    /// <remarks>
    /// These flags are expected to exist in the high-word of a double-word flag set such that original word flags remain in-tact
    /// in low-word of double-word flag set.
    /// </remarks>
    [Flags(), Serializable()]
    public enum CommonStatusFlags : uint
    {
        /// <summary>
        /// Data is valid (0 when device data is valid, 1 when invalid or device is in test mode).
        /// </summary>
        DataIsValid = (uint)Bits.Bit19,
        /// <summary>
        /// Synchronization is valid (0 when in device is in sync, 1 when it is not).
        /// </summary>
        SynchronizationIsValid = (uint)Bits.Bit18,
        /// <summary>
        /// Data sorting type, 0 by timestamp, 1 by arrival.
        /// </summary>
        DataSortingType = (uint)Bits.Bit17,
        /// <summary>
        /// Device error (including configuration error), 0 when no error.
        /// </summary>
        DeviceError = (uint)Bits.Bit16,
        /// <summary>
        /// Reserved bits for future common flags, presently set to 0.
        /// </summary>
        ReservedFlags = (uint)(Bits.Bit20 | Bits.Bit21 | Bits.Bit22 | Bits.Bit23 | Bits.Bit24 | Bits.Bit25 | Bits.Bit26 | Bits.Bit27 | Bits.Bit28 | Bits.Bit29 | Bits.Bit30 | Bits.Bit31),
        /// <summary>
        /// No flags.
        /// </summary>
        NoFlags = (uint)Bits.Nil
    }

    #endregion

    /// <summary>
    /// Represents the protocol independent common implementation of all elements for cells in a <see cref="IDataFrame"/>.
    /// </summary>
    [Serializable()]
    public abstract class DataCellBase : ChannelCellBase, IDataCell
    {
        #region [ Members ]

        // Fields
        private IConfigurationCell m_configurationCell;
        private ushort m_statusFlags;
        private PhasorValueCollection m_phasorValues;
        private IFrequencyValue m_frequencyValue;
        private AnalogValueCollection m_analogValues;
        private DigitalValueCollection m_digitalValues;

        // IMeasurement implementation fields
        private uint m_id;
        private string m_source;
        private MeasurementKey m_key;
        private Guid m_signalID;
        private string m_tagName;
        private Ticks m_timestamp;
        private double m_adder;
        private double m_multiplier;
        private MeasurementValueFilterFunction m_measurementValueFilter;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="DataCellBase"/> from specified parameters.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="IDataFrame"/> of this <see cref="DataCellBase"/>.</param>
        /// <param name="configurationCell">The <see cref="IConfigurationCell"/> associated with this <see cref="DataCellBase"/>.</param>
        /// <param name="maximumPhasors">Sets the maximum number of phasors for the <see cref="PhasorValues"/> collection.</param>
        /// <param name="maximumAnalogs">Sets the maximum number of phasors for the <see cref="AnalogValues"/> collection.</param>
        /// <param name="maximumDigitals">Sets the maximum number of phasors for the <see cref="DigitalValues"/> collection.</param>
        protected DataCellBase(IDataFrame parent, IConfigurationCell configurationCell, int maximumPhasors, int maximumAnalogs, int maximumDigitals)
            : base(parent, 0)
        {
            m_configurationCell = configurationCell;
            m_statusFlags = ushort.MaxValue;
            m_phasorValues = new PhasorValueCollection(maximumPhasors);
            m_analogValues = new AnalogValueCollection(maximumAnalogs);
            m_digitalValues = new DigitalValueCollection(maximumDigitals);

            // Initialize IMeasurement members
            m_id = uint.MaxValue;
            m_source = "__";
            m_key = PhasorProtocols.Common.UndefinedKey;
            m_timestamp = -1;
            m_multiplier = 1.0D;
        }

        /// <summary>
        /// Creates a new <see cref="DataCellBase"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected DataCellBase(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Deserialize data cell values
            m_configurationCell = (IConfigurationCell)info.GetValue("configurationCell", typeof(IConfigurationCell));
            m_statusFlags = info.GetUInt16("statusFlags");
            m_phasorValues = (PhasorValueCollection)info.GetValue("phasorValues", typeof(PhasorValueCollection));
            m_frequencyValue = (IFrequencyValue)info.GetValue("frequencyValue", typeof(IFrequencyValue));
            m_analogValues = (AnalogValueCollection)info.GetValue("analogValues", typeof(AnalogValueCollection));
            m_digitalValues = (DigitalValueCollection)info.GetValue("digitalValues", typeof(DigitalValueCollection));
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the reference to parent <see cref="IDataFrame"/> of this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual new IDataFrame Parent
        {
            get
            {
                return base.Parent as IDataFrame;
            }
            set
            {
                base.Parent = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IConfigurationCell"/> associated with this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual IConfigurationCell ConfigurationCell
        {
            get
            {
                return m_configurationCell;
            }
            set
            {
                m_configurationCell = value;
            }
        }

        /// <summary>
        /// Gets or sets the parsing state for the this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual new IDataCellParsingState State
        {
            get
            {
                return base.State as IDataCellParsingState;
            }
            set
            {
                base.State = value;
            }
        }

        /// <summary>
        /// Gets station name of this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual string StationName
        {
            get
            {
                return m_configurationCell.StationName;
            }
        }

        /// <summary>
        /// Gets ID label of this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual string IDLabel
        {
            get
            {
                return m_configurationCell.IDLabel;
            }
        }

        /// <summary>
        /// Gets or sets 16-bit status flags of this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual ushort StatusFlags
        {
            get
            {
                return m_statusFlags;
            }
            set
            {
                m_statusFlags = value;
            }
        }

        /// <summary>
        /// Gets the numeric ID code for this <see cref="DataCellBase"/>.
        /// </summary>
        /// <remarks>
        /// This value is read-only for <see cref="DataCellBase"/>; assigning a value will throw an exception. Value returned
        /// is the <see cref="IChannelCell.IDCode"/> of the associated <see cref="ConfigurationCell"/>.
        /// </remarks>
        /// <exception cref="NotSupportedException">IDCode of a data cell is read-only, change IDCode is associated configuration cell instead.</exception>
        public override ushort IDCode
        {
            get
            {
                return m_configurationCell.IDCode;
            }
            set
            {
                throw new NotSupportedException("IDCode of a data cell is read-only, change IDCode is associated configuration cell instead");
            }
        }

        /// <summary>
        /// Gets or sets common status flags of this <see cref="DataCellBase"/>.
        /// </summary>
        public uint CommonStatusFlags
        {
            get
            {
                // Start with lo-word protocol specific flags
                uint commonFlags = StatusFlags;

                // Add hi-word protocol independent common flags
                if (!DataIsValid)
                    commonFlags |= (uint)PhasorProtocols.CommonStatusFlags.DataIsValid;

                if (!SynchronizationIsValid)
                    commonFlags |= (uint)PhasorProtocols.CommonStatusFlags.SynchronizationIsValid;

                if (DataSortingType != PhasorProtocols.DataSortingType.ByTimestamp)
                    commonFlags |= (uint)PhasorProtocols.CommonStatusFlags.DataSortingType;

                if (DeviceError)
                    commonFlags |= (uint)PhasorProtocols.CommonStatusFlags.DeviceError;

                return commonFlags;
            }
            set
            {
                // Deriving common states requires clearing of base status flags...
                if (value != uint.MaxValue)
                    StatusFlags = 0;

                // Derive common states via common status flags
                DataIsValid = (value & (uint)PhasorProtocols.CommonStatusFlags.DataIsValid) == 0;
                SynchronizationIsValid = (value & (uint)PhasorProtocols.CommonStatusFlags.SynchronizationIsValid) == 0;
                DataSortingType = ((value & (uint)PhasorProtocols.CommonStatusFlags.DataSortingType) == 0) ? PhasorProtocols.DataSortingType.ByTimestamp : PhasorProtocols.DataSortingType.ByArrival;
                DeviceError = ((value & (uint)PhasorProtocols.CommonStatusFlags.DeviceError) > 0 );
            }
        }

        /// <summary>
        /// Gets flag that determines if all values of this <see cref="DataCellBase"/> have been assigned.
        /// </summary>
        public virtual bool AllValuesAssigned
        {
            get
            {
                return (PhasorValues.AllValuesAssigned && !FrequencyValue.IsEmpty && AnalogValues.AllValuesAssigned && DigitalValues.AllValuesAssigned);
            }
        }

        /// <summary>
        /// Gets <see cref="PhasorValueCollection"/> of this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual PhasorValueCollection PhasorValues
        {
            get
            {
                return m_phasorValues;
            }
        }

        /// <summary>
        /// Gets <see cref="IFrequencyValue"/> of this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual IFrequencyValue FrequencyValue
        {
            get
            {
                return m_frequencyValue;
            }
            set
            {
                m_frequencyValue = value;
            }
        }

        /// <summary>
        /// Gets <see cref="AnalogValueCollection"/>of this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual AnalogValueCollection AnalogValues
        {
            get
            {
                return m_analogValues;
            }
        }

        /// <summary>
        /// Gets <see cref="DigitalValueCollection"/>of this <see cref="DataCellBase"/>.
        /// </summary>
        public virtual DigitalValueCollection DigitalValues
        {
            get
            {
                return m_digitalValues;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if data of this <see cref="DataCellBase"/> is valid.
        /// </summary>
        /// <remarks>
        /// This value is used to abstractly assign the protocol independent set of <see cref="CommonStatusFlags"/>.
        /// </remarks>
        public abstract bool DataIsValid { get; set; }

        /// <summary>
        /// Gets or sets flag that determines if timestamp of this <see cref="DataCellBase"/> is valid based on GPS lock.
        /// </summary>
        /// <remarks>
        /// This value is used to abstractly assign the protocol independent set of <see cref="CommonStatusFlags"/>.
        /// </remarks>
        public abstract bool SynchronizationIsValid { get; set; }

        /// <summary>
        /// Gets or sets <see cref="PhasorProtocols.DataSortingType"/> of this <see cref="DataCellBase"/>.
        /// </summary>
        /// <remarks>
        /// This value is used to abstractly assign the protocol independent set of <see cref="CommonStatusFlags"/>.
        /// </remarks>
        public abstract DataSortingType DataSortingType { get; set; }

        /// <summary>
        /// Gets or sets flag that determines if source device of this <see cref="DataCellBase"/> is reporting an error.
        /// </summary>
        /// <remarks>
        /// This value is used to abstractly assign the protocol independent set of <see cref="CommonStatusFlags"/>.
        /// </remarks>
        public abstract bool DeviceError { get; set; }

        /// <summary>
        /// Gets the length of the <see cref="BodyImage"/>.
        /// </summary>
        protected override int BodyLength
        {
            get
            {
                return 2 + m_phasorValues.BinaryLength + m_frequencyValue.BinaryLength + m_analogValues.BinaryLength + m_digitalValues.BinaryLength;
            }
        }

        /// <summary>
        /// Gets the binary body image of the <see cref="DataCellBase"/> object.
        /// </summary>
        protected override byte[] BodyImage
        {
            get
            {
                byte[] buffer = new byte[BodyLength];
                int index = 0;

                // Copy in common cell image
                EndianOrder.BigEndian.CopyBytes(m_statusFlags, buffer, index);
                index += 2;

                m_phasorValues.CopyImage(buffer, ref index);
                m_frequencyValue.CopyImage(buffer, ref index);
                m_analogValues.CopyImage(buffer, ref index);
                m_digitalValues.CopyImage(buffer, ref index);

                return buffer;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for the <see cref="DataCellBase"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                baseAttributes.Add("Station Name", StationName);
                baseAttributes.Add("ID Label", IDLabel);
                baseAttributes.Add("Status Flags", StatusFlags.ToString());
                baseAttributes.Add("Data Is Valid", DataIsValid.ToString());
                baseAttributes.Add("Synchronization Is Valid", SynchronizationIsValid.ToString());
                baseAttributes.Add("Data Sorting Type", Enum.GetName(typeof(DataSortingType), DataSortingType));
                baseAttributes.Add("Device Error", DeviceError.ToString());
                baseAttributes.Add("Total Phasor Values", PhasorValues.Count.ToString());
                baseAttributes.Add("Total Analog Values", AnalogValues.Count.ToString());
                baseAttributes.Add("Total Digital Values", DigitalValues.Count.ToString());
                baseAttributes.Add("All Values Assigned", AllValuesAssigned.ToString());

                return baseAttributes;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Parses the binary body image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        protected override int ParseBodyImage(byte[] binaryImage, int startIndex, int length)
        {
            // Length is validated at a frame level well in advance so that low level parsing routines do not have
            // to re-validate that enough length is available to parse needed information as an optimization...

            IDataCellParsingState parsingState = State;
            IPhasorValue phasorValue;
            IAnalogValue analogValue;
            IDigitalValue digitalValue;
            int x, parsedLength, index = startIndex;

            StatusFlags = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex);
            index += 2;

            // By the very nature of the major phasor protocols supporting the same order of phasors, frequency, df/dt, analog and digitals
            // we are able to "automatically" parse this data out in the data cell base class - BEAUTIFUL!!!

            // Parse out phasor values
            for (x = 0; x < parsingState.PhasorCount; x++)
            {
                phasorValue = parsingState.CreateNewPhasorValue(this, m_configurationCell.PhasorDefinitions[x], binaryImage, index, out parsedLength);
                m_phasorValues.Add(phasorValue);
                index += parsedLength;
            }

            // Parse out frequency and df/dt values
            m_frequencyValue = parsingState.CreateNewFrequencyValue(this, m_configurationCell.FrequencyDefinition, binaryImage, index, out parsedLength);
            index += parsedLength;

            // Parse out analog values
            for (x = 0; x < parsingState.AnalogCount; x++)
            {
                analogValue = parsingState.CreateNewAnalogValue(this, m_configurationCell.AnalogDefinitions[x], binaryImage, index, out parsedLength);
                m_analogValues.Add(analogValue);
                index += parsedLength;
            }

            // Parse out digital values
            for (x = 0; x < parsingState.DigitalCount; x++)
            {
                digitalValue = parsingState.CreateNewDigitalValue(this, m_configurationCell.DigitalDefinitions[x], binaryImage, index, out parsedLength);
                m_digitalValues.Add(digitalValue);
                index += parsedLength;
            }

            // Return total parsed length
            return (index - startIndex);
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            // Serialize data cell values
            info.AddValue("configurationCell", m_configurationCell, typeof(IConfigurationCell));
            info.AddValue("statusFlags", m_statusFlags);
            info.AddValue("phasorValues", m_phasorValues, typeof(PhasorValueCollection));
            info.AddValue("frequencyValue", m_frequencyValue, typeof(IFrequencyValue));
            info.AddValue("analogValues", m_analogValues, typeof(AnalogValueCollection));
            info.AddValue("digitalValues", m_digitalValues, typeof(DigitalValueCollection));
        }

        /// <summary>
        /// Returns a string representation of the status flags.
        /// </summary>
        /// <returns>A string representation of the status flags <see cref="IMeasurement"/>.</returns>
        public override string ToString()
        {
            return Measurement.ToString(this);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the <see cref="DataCellBase"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the <see cref="DataCellBase"/>.</param>
        /// <returns>true if the specified object is equal to the <see cref="DataCellBase"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            IMeasurement measurement = obj as IMeasurement;

            // If comparing to another measurment, use hash code for equality
            if (measurement != null)
                return ((IMeasurement)this).Equals(measurement);

            // Otherwise use default equality comparison
            return base.Equals(obj);
        }

        /// <summary>
        /// Serves as a hash function for the <see cref="DataCellBase"/>.
        /// </summary>
        /// <returns>A hash code for the <see cref="DataCellBase"/>.</returns>
        /// <remarks>Hash code based on value of measurement key associated with the <see cref="DataCellBase"/>.</remarks>
        public override int GetHashCode()
        {
            return ((IMeasurement)this).GetHashCode();
        }

        #endregion

        #region [ IMeasurement Implementation ]

        // We keep the IMeasurement implementation of the DataCell completely private.  Exposing
        // these properties publically would only stand to add confusion as to where measurements
        // typically come from (i.e., the IDataCell's values) - the only value the cell itself has
        // to offer is the "CommonStatusFlags" property, which we expose below...

        double IMeasurement.Value
        {
            get
            {
                return CommonStatusFlags;
            }
            set
            {
                CommonStatusFlags = (uint)value;
            }
        }

        // The only "measured value" a data cell exposes is its "StatusFlags"
        double IMeasurement.AdjustedValue
        {
            get
            {
                return (double)CommonStatusFlags * m_multiplier + m_adder;
            }
        }

        // I don't imagine you would want offsets for status flags - but this may yet be handy for
        // "forcing" a particular set of quality flags to come through the system (M=0, A=New Flags)
        double IMeasurement.Adder
        {
            get
            {
                return m_adder;
            }
            set
            {
                m_adder = value;
            }
        }

        double IMeasurement.Multiplier
        {
            get
            {
                return m_multiplier;
            }
            set
            {
                m_multiplier = value;
            }
        }

        Ticks IMeasurement.Timestamp
        {
            get
            {
                if (m_timestamp == -1)
                    m_timestamp = Parent.Timestamp;

                return m_timestamp;
            }
            set
            {
                m_timestamp = value;
            }
        }

        uint IMeasurement.ID
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }

        string IMeasurement.Source
        {
            get
            {
                return m_source;
            }
            set
            {
                m_source = value;
            }
        }

        MeasurementKey IMeasurement.Key
        {
            get
            {
                if (m_key.Equals(PhasorProtocols.Common.UndefinedKey))
                    m_key = new MeasurementKey(m_id, m_source);

                return m_key;
            }
        }

        Guid IMeasurement.SignalID
        {
            get
            {
                return m_signalID;
            }
            set
            {
                m_signalID = value;
            }
        }

        MeasurementValueFilterFunction IMeasurement.MeasurementValueFilter
        {
            get
            {
                // If measurement user has assigned another filter for this measurement,
                // we'll use it instead
                if (m_measurementValueFilter != null)
                    return m_measurementValueFilter;

                // Otherwise, status flags are digital in nature, so we return a majority item filter
                return Measurement.MajorityValueFilter;
            }
            set
            {
                m_measurementValueFilter = value;
            }
        }

        bool IMeasurement.ValueQualityIsGood
        {
            get
            {
                return this.DataIsValid;
            }
            set
            {
                this.DataIsValid = value;
            }
        }

        bool IMeasurement.TimestampQualityIsGood
        {
            get
            {
                return this.SynchronizationIsValid;
            }
            set
            {
                this.SynchronizationIsValid = value;
            }
        }

        string IMeasurement.TagName
        {
            get
            {
                return m_tagName;
            }
            set
            {
                m_tagName = value;
            }
        }

        int IMeasurement.GetHashCode()
        {
            return ((IMeasurement)this).Key.GetHashCode();
        }

        int IComparable.CompareTo(object obj)
        {
            IMeasurement measurement = obj as IMeasurement;

            if (measurement != null)
                return (this as IComparable<IMeasurement>).CompareTo(measurement);

            throw new ArgumentException("Measurement can only be compared with other IMeasurements...");
        }

        int IComparable<IMeasurement>.CompareTo(IMeasurement other)
        {
            return (this as IMeasurement).GetHashCode().CompareTo(other.GetHashCode());
        }

        bool IEquatable<IMeasurement>.Equals(IMeasurement other)
        {
            return ((this as IComparable<IMeasurement>).CompareTo(other) == 0);
        }

        #endregion
    }
}