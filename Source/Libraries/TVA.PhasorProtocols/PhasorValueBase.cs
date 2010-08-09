//*******************************************************************************************************
//  PhasorValueBase.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  11/12/2004 - J. Ritchie Carroll
//       Generated original version of source code.
//  08/07/2009 - Josh L. Patterson
//       Edited Comments.
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
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using TVA.Units;
using TVA.Measurements;

namespace TVA.PhasorProtocols
{
    #region [ Enumerations ]

    /// <summary>
    /// Composite polar value indicies enumeration.
    /// </summary>
    public enum CompositePhasorValue
    {
        /// <summary>
        /// Composite angle value index.
        /// </summary>
        Angle,
        /// <summary>
        /// Composite magnitude value index.
        /// </summary>
        Magnitude
    }

    #endregion

    /// <summary>
    /// Represents the common implementation of the protocol independent representation of a phasor value.
    /// </summary>
    [Serializable()]
    public abstract class PhasorValueBase : ChannelValueBase<IPhasorDefinition>, IPhasorValue
    {
        #region [ Members ]

        // Fields
        private ComplexNumber m_phasor;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="PhasorValueBase"/>.
        /// </summary>
        /// <param name="parent">The <see cref="IDataCell"/> parent of this <see cref="PhasorValueBase"/>.</param>
        /// <param name="phasorDefinition">The <see cref="IPhasorDefinition"/> associated with this <see cref="PhasorValueBase"/>.</param>
        protected PhasorValueBase(IDataCell parent, IPhasorDefinition phasorDefinition)
            : base(parent, phasorDefinition)
        {
        }

        /// <summary>
        /// Creates a new <see cref="PhasorValueBase"/> from specified parameters.
        /// </summary>
        /// <param name="parent">The <see cref="IDataCell"/> parent of this <see cref="PhasorValueBase"/>.</param>
        /// <param name="phasorDefinition">The <see cref="IPhasorDefinition"/> associated with this <see cref="PhasorValueBase"/>.</param>
        /// <param name="real">The real value of this <see cref="PhasorValueBase"/>.</param>
        /// <param name="imaginary">The imaginary value of this <see cref="PhasorValueBase"/>.</param>
        protected PhasorValueBase(IDataCell parent, IPhasorDefinition phasorDefinition, double real, double imaginary)
            : base(parent, phasorDefinition)
        {
            m_phasor.Real = real;
            m_phasor.Imaginary = imaginary;
        }

        /// <summary>
        /// Creates a new <see cref="PhasorValueBase"/> from specified parameters.
        /// </summary>
        /// <param name="parent">The <see cref="IDataCell"/> parent of this <see cref="PhasorValueBase"/>.</param>
        /// <param name="phasorDefinition">The <see cref="IPhasorDefinition"/> associated with this <see cref="PhasorValueBase"/>.</param>
        /// <param name="angle">The <see cref="TVA.Units.Angle"/> value (a.k.a., the argument) of this <see cref="PhasorValueBase"/>, in radians.</param>
        /// <param name="magnitude">The magnitude value (a.k.a., the absolute value or modulus) of this <see cref="PhasorValueBase"/>.</param>
        protected PhasorValueBase(IDataCell parent, IPhasorDefinition phasorDefinition, Angle angle, double magnitude)
            : base(parent, phasorDefinition)
        {
            m_phasor.Angle = angle;
            m_phasor.Magnitude = magnitude;
        }

        /// <summary>
        /// Creates a new <see cref="PhasorValueBase"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected PhasorValueBase(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Deserialize phasor value
            m_phasor.Real = info.GetDouble("real");
            m_phasor.Imaginary = info.GetDouble("imaginary");
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets the <see cref="PhasorProtocols.CoordinateFormat"/> of this <see cref="PhasorValueBase"/>.
        /// </summary>
        public virtual CoordinateFormat CoordinateFormat
        {
            get
            {
                return Definition.CoordinateFormat;
            }
        }

        /// <summary>
        /// Gets the <see cref="PhasorType"/> of this <see cref="PhasorValueBase"/>.
        /// </summary>
        public virtual PhasorType Type
        {
            get
            {
                return Definition.PhasorType;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="TVA.Units.Angle"/> value (a.k.a., the argument) of this <see cref="PhasorValueBase"/>, in radians.
        /// </summary>
        public virtual Angle Angle
        {
            get
            {
                return m_phasor.Angle;
            }
            set
            {
                m_phasor.Angle = value;
            }
        }

        /// <summary>
        /// Gets or sets the magnitude value (a.k.a., the absolute value or modulus) of this <see cref="PhasorValueBase"/>.
        /// </summary>
        public virtual double Magnitude
        {
            get
            {
                return m_phasor.Magnitude;
            }
            set
            {
                m_phasor.Magnitude = value;
            }
        }

        /// <summary>
        /// Gets or sets the real value of this <see cref="PhasorValueBase"/>.
        /// </summary>
        public virtual double Real
        {
            get
            {
                return m_phasor.Real;
            }
            set
            {
                m_phasor.Real = value;
            }
        }

        /// <summary>
        /// Gets or sets the imaginary value of this <see cref="PhasorValueBase"/>.
        /// </summary>
        public virtual double Imaginary
        {
            get
            {
                return m_phasor.Imaginary;
            }
            set
            {
                m_phasor.Imaginary = value;
            }
        }

        /// <summary>
        /// Gets or sets the unscaled integer representation of the real value of this <see cref="PhasorValueBase"/>.
        /// </summary>
        public virtual int UnscaledReal
        {
            get
            {
                unchecked
                {
                    return (int)(m_phasor.Real / Definition.ConversionFactor);
                }
            }
            set
            {
                m_phasor.Real = value * Definition.ConversionFactor;
            }
        }

        /// <summary>
        /// Gets or sets the unscaled integer representation of the imaginary value of this <see cref="PhasorValueBase"/>.
        /// </summary>
        public virtual int UnscaledImaginary
        {
            get
            {
                unchecked
                {
                    return (int)(m_phasor.Imaginary / Definition.ConversionFactor);
                }
            }
            set
            {
                m_phasor.Imaginary = value * Definition.ConversionFactor;
            }
        }

        /// <summary>
        /// Gets total number of composite values that this <see cref="PhasorValueBase"/> provides.
        /// </summary>
        public override int CompositeValueCount
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Gets boolean value that determines if none of the composite values of <see cref="PhasorValueBase"/> have been assigned a value.
        /// </summary>
        public override bool IsEmpty
        {
            get
            {
                return m_phasor.NoneAssigned;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="BodyImage"/>.
        /// </summary>
        /// <remarks>
        /// The base implementation assumes fixed integer values are represented as 16-bit signed
        /// integers and floating point values are represented as 32-bit single-precision floating-point
        /// values (i.e., short and float data types respectively).
        /// </remarks>
        protected override int BodyLength
        {
            get
            {
                if (DataFormat == PhasorProtocols.DataFormat.FixedInteger)
                    return 4;
                else
                    return 8;
            }
        }

        /// <summary>
        /// Gets the binary body image of the <see cref="PhasorValueBase"/> object.
        /// </summary>
        /// <remarks>
        /// The base implementation assumes fixed integer values are represented as 16-bit signed
        /// integers and floating point values are represented as 32-bit single-precision floating-point
        /// values (i.e., short and float data types respectively).
        /// </remarks>
        protected override byte[] BodyImage
        {
            get
            {
                byte[] buffer = new byte[BodyLength];

                // Had to make a descision on usage versus typical protocol implementation when
                // exposing values as double / int when protocols typically use float / short for
                // transmission. Exposing values as double / int makes class more versatile by
                // allowing future protocol implementations to support higher resolution values
                // simply by overriding BodyLength, BodyImage and ParseBodyImage. However, exposing
                // the double / int values runs the risk of providing values that are outside the
                // data type limitations, hence the unchecked section below. Risk should generally
                // be low in typical usage scenarios since values being transmitted via a generated
                // image were likely parsed previously from a binary image with the same constraints.
                unchecked
                {
                    if (CoordinateFormat == PhasorProtocols.CoordinateFormat.Rectangular)
                    {
                        if (DataFormat == PhasorProtocols.DataFormat.FixedInteger)
                        {
                            EndianOrder.BigEndian.CopyBytes((short)UnscaledReal, buffer, 0);
                            EndianOrder.BigEndian.CopyBytes((short)UnscaledImaginary, buffer, 2);
                        }
                        else
                        {
                            EndianOrder.BigEndian.CopyBytes((float)m_phasor.Real, buffer, 0);
                            EndianOrder.BigEndian.CopyBytes((float)m_phasor.Imaginary, buffer, 4);
                        }
                    }
                    else
                    {
                        if (DataFormat == PhasorProtocols.DataFormat.FixedInteger)
                        {
                            EndianOrder.BigEndian.CopyBytes((ushort)(m_phasor.Magnitude / Definition.ConversionFactor), buffer, 0);
                            EndianOrder.BigEndian.CopyBytes((short)(m_phasor.Angle * 10000.0D), buffer, 2);
                        }
                        else
                        {
                            EndianOrder.BigEndian.CopyBytes((float)m_phasor.Magnitude, buffer, 0);
                            EndianOrder.BigEndian.CopyBytes((float)m_phasor.Angle, buffer, 4);
                        }
                    }
                }

                return buffer;
            }
        }

        /// <summary>
        /// Gets a <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for this <see cref="PhasorValueBase"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                baseAttributes.Add("Phasor Type", (int)Type + ": " + Type);
                baseAttributes.Add("Angle Value", Angle.ToDegrees() + "°");
                baseAttributes.Add("Magnitude Value", Magnitude.ToString());
                baseAttributes.Add("Real Value", Real.ToString());
                baseAttributes.Add("Imaginary Value", Imaginary.ToString());
                baseAttributes.Add("Unscaled Real Value", UnscaledReal.ToString());
                baseAttributes.Add("Unscaled Imaginary Value", UnscaledImaginary.ToString());
                
                return baseAttributes;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Gets the specified composite value of this <see cref="PhasorValueBase"/>.
        /// </summary>
        /// <param name="index">Index of composite value to retrieve.</param>
        /// <remarks>
        /// Some <see cref="ChannelValueBase{T}"/> implementations can contain more than one value, this method is used to abstractly expose each value.
        /// </remarks>
        /// <returns>A <see cref="Double"/> representing the composite value.</returns>
        public override double GetCompositeValue(int index)
        {
            switch (index)
            {
                case (int)CompositePhasorValue.Angle:
                    return Angle.ToDegrees();
                case (int)CompositePhasorValue.Magnitude:
                    return Magnitude;
                default:
                    throw new ArgumentOutOfRangeException("index", "Invalid composite index requested");
            }
        }

        /// <summary>
        /// Gets function used to apply a downsampling filter over a sequence of <see cref="IMeasurement"/> values.
        /// </summary>
        /// <param name="index">Index of composite value for which to retrieve its filter function.</param>
        /// <returns>Function used to apply a downsampling filter over a sequence of <see cref="IMeasurement"/> values.</returns>
        /// <remarks>
        /// Phase angles averaging filter takes angle wrapping into account, magnitudes apply a standard average filter.
        /// </remarks>
        public override MeasurementValueFilterFunction GetMeasurementValueFilterFunction(int index)
        {
            switch (index)
            {
                case (int)CompositePhasorValue.Angle:
                    return PhasorValueBase.AverageAngleValueFilter;
                case (int)CompositePhasorValue.Magnitude:
                    return Measurement.AverageValueFilter;
                default:
                    throw new ArgumentOutOfRangeException("index", "Invalid composite index requested");
            }
        }

        /// <summary>
        /// Parses the binary body image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        /// <remarks>
        /// The base implementation assumes fixed integer values are represented as 16-bit signed
        /// integers and floating point values are represented as 32-bit single-precision floating-point
        /// values (i.e., short and float data types respectively).
        /// </remarks>
        protected override int ParseBodyImage(byte[] binaryImage, int startIndex, int length)
        {
            // Length is validated at a frame level well in advance so that low level parsing routines do not have
            // to re-validate that enough length is available to parse needed information as an optimization...

            if (DataFormat == PhasorProtocols.DataFormat.FixedInteger)
            {
                if (CoordinateFormat == PhasorProtocols.CoordinateFormat.Rectangular)
                {
                    // Parse from fixed-integer, rectangular
                    UnscaledReal = EndianOrder.BigEndian.ToInt16(binaryImage, startIndex);
                    UnscaledImaginary = EndianOrder.BigEndian.ToInt16(binaryImage, startIndex + 2);
                }
                else
                {
                    // Parse from fixed-integer, polar
                    m_phasor.Magnitude = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex) * Definition.ConversionFactor;
                    m_phasor.Angle = EndianOrder.BigEndian.ToInt16(binaryImage, startIndex + 2) / 10000.0D;
                }

                return 4;
            }
            else
            {
                if (CoordinateFormat == PhasorProtocols.CoordinateFormat.Rectangular)
                {
                    // Parse from single-precision floating-point, rectangular
                    m_phasor.Real = EndianOrder.BigEndian.ToSingle(binaryImage, startIndex);
                    m_phasor.Imaginary = EndianOrder.BigEndian.ToSingle(binaryImage, startIndex + 4);
                }
                else
                {
                    // Parse from single-precision floating-point, polar
                    m_phasor.Magnitude = EndianOrder.BigEndian.ToSingle(binaryImage, startIndex);
                    m_phasor.Angle = EndianOrder.BigEndian.ToSingle(binaryImage, startIndex + 4);
                }

                return 8;
            }
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            // Serialize phasor value
            info.AddValue("real", m_phasor.Real);
            info.AddValue("imaginary", m_phasor.Imaginary);
        }

        #endregion

        #region [ Static ]

        // Static Methods

        /// <summary>
        /// Calculates watts from imaginary and real components of a voltage and current phasor.
        /// </summary>
        /// <param name="voltage">Voltage phasor.</param>
        /// <param name="current">Current phasor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="voltage"/> and <paramref name="current"/> must not be null.</exception>
        /// <returns>Calculated watts from imaginary and real components of specified <paramref name="voltage"/> and <paramref name="current"/> phasors.</returns>
        public static Power CalculatePower(IPhasorValue voltage, IPhasorValue current)
        {
            if (voltage == null)
                throw new ArgumentNullException("voltage", "No voltage specified");

            if (current == null)
                throw new ArgumentNullException("current", "No current specified");

            return 3 * (voltage.Real * current.Real + voltage.Imaginary * current.Imaginary);
            //Return 3 * voltage.Magnitude * current.Magnitude * System.Math.Cos(voltage.Angle - current.Angle)
        }

        /// <summary>
        /// Calculates vars (total volt-amperes of reactive power) from imaginary and real components of a voltage and current phasor.
        /// </summary>
        /// <param name="voltage">Voltage phasor.</param>
        /// <param name="current">Current phasor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="voltage"/> and <paramref name="current"/> must not be null.</exception>
        /// <remarks>
        /// Although the <see cref="Power"/> units class technically represents watts (i.e., real power) and vars (i.e., imaginary power)
        /// are properly expressed in volt-amperes reactive (VAr), the calculated result is still a representation of power and therefore
        /// the <see cref="Power"/> units class is used to express the return value leaving the consumer to properly apply the needed
        /// engineering units for display purposes.
        /// </remarks>
        /// <returns>Calculated vars (total volt-amperes of reactive power) from imaginary and real components of specified <paramref name="voltage"/> and <paramref name="current"/> phasors.</returns>
        public static Power CalculateVars(IPhasorValue voltage, IPhasorValue current)
        {
            if (voltage == null)
                throw new ArgumentNullException("voltage", "No voltage specified");

            if (current == null)
                throw new ArgumentNullException("current", "No current specified");

            return 3 * (voltage.Imaginary * current.Real - voltage.Real * current.Imaginary);
            //Return 3 * voltage.Magnitude * current.Magnitude * System.Math.Sin(voltage.Angle - current.Angle)
        }

        /// <summary>
        /// Calculates an average of the specified sequence of <see cref="IMeasurement"/> phase angle values.
        /// </summary>
        /// <param name="source">Sequence of <see cref="IMeasurement"/> values over which to run calculation.</param>
        /// <returns>Average of the specified sequence of <see cref="IMeasurement"/> phase angle values.</returns>
        /// <remarks>
        /// Phase angles wrap, so this algorithm takes the wrapping into account when calculating the average.
        /// </remarks>
        public static double AverageAngleValueFilter(IEnumerable<IMeasurement> source)
        {
            double average = 0.0D;
            double[] sourceAngles = source.Select(m => m.Value).ToArray();

            if (sourceAngles.Length > 0)
            {
                double offset = 0.0D, dis0, dis1, dis2;
                double[] unwrappedAngles = new double[sourceAngles.Length];

                unwrappedAngles[0] = sourceAngles[0];

                // Unwrap all source angles
                for (int i = 1; i < sourceAngles.Length; i++)
                {
                    dis0 = Math.Abs(sourceAngles[i] + offset - unwrappedAngles[i - 1]);
                    dis1 = Math.Abs(sourceAngles[i] + offset - unwrappedAngles[i - 1] + 360.0D);
                    dis2 = Math.Abs(sourceAngles[i] + offset - unwrappedAngles[i - 1] - 360.0D);

                    if (dis1 < dis0 && dis1 < dis2)
                        offset = offset + 360.0D;
                    else if (dis2 < dis0 && dis2 < dis1)
                        offset = offset - 360.0D;

                    unwrappedAngles[i] = sourceAngles[i] + offset;
                }

                // Apply average to unwrapped angles
                average = unwrappedAngles.Average();

                // Re-wrap average angle
                while (!(average <= 180.0D && average > -180.0D))
                {
                    if (average > 180.0D)
                        average -= 360.0D;

                    if (average <= -180.0D)
                        average += 360.0D;
                }
            }

            return average;
        }

        #endregion
    }
}