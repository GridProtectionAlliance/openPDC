using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVA.PhasorProtocols;

namespace COMTRADE
{
    /// <summary>
    /// Represents an analog channel defintion of the <see cref="PhasorDataSchema"/>.
    /// </summary>
    public class AnalogChannel
    {
        #region [ Members ]

        // Nested Types

        // Constants

        // Delegates

        // Events

        // Fields
        private int m_index;
        private string m_stationName;
        private string m_channelName;
        private char m_phaseDesignation;
        private SignalKind m_signalKind;
        private CoordinateFormat m_coordinateFormat;
        private List<char> m_validPhaseDesignations;
        private List<SignalKind> m_validAnalogSignalKinds;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="AnalogChannel"/>.
        /// </summary>
        public AnalogChannel()
        {
            m_phaseDesignation = char.MinValue;
            m_signalKind = SignalKind.Analog;
            m_coordinateFormat = CoordinateFormat.Polar;
            m_validPhaseDesignations = new List<char>(new char[] { 'A', 'B', 'C', 'R', 'S', 'T', '1', '2', '3', 'P', '+', 'N', '-', 'Z', '0'});
            m_validPhaseDesignations.Sort();
            m_validAnalogSignalKinds = new List<SignalKind>(new SignalKind[] { SignalKind.Analog, SignalKind.Angle, SignalKind.Calculation, SignalKind.DfDt, SignalKind.Frequency, SignalKind.Magnitude, SignalKind.Statistic });
            m_validAnalogSignalKinds.Sort();
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets name of this <see cref="AnalogChannel"/> formatted as station_name:channel_name.
        /// </summary>
        /// <exception cref="FormatException">Name must be formatted as station_name:channel_name.</exception>
        public string Name
        {
            get
            {
                return string.Format("{0}:{1}", m_stationName, m_channelName);
            }
            set
            {
                string[] parts = value.Split(':');

                if (parts.Length != 2)
                    throw new FormatException("Analog channel name must be formatted as station_name:channel_name.");

                m_stationName = parts[0].Trim();
                m_channelName = parts[1].Trim();
            }
        }

        /// <summary>
        /// Gets or sets station name component of this <see cref="AnalogChannel"/>.
        /// </summary>
        public string StationName
        {
            get
            {
                return m_stationName;
            }
            set
            {
                m_stationName = value.Replace(":", "").Trim();
            }
        }

        /// <summary>
        /// Gets or sets channel name component of this <see cref="AnalogChannel"/>.
        /// </summary>
        public string ChannelName
        {
            get
            {
                return m_channelName;
            }
            set
            {
                m_channelName = value.Replace(":", "").Trim();
            }
        }

        /// <summary>
        /// Gets or sets the 2-character phase identifier for this <see cref="AnalogChannel"/>.
        /// </summary>
        public string PhaseID
        {
            get
            {
                switch (m_signalKind)
                {
                    case SignalKind.Magnitude:
                        if (m_phaseDesignation != char.MinValue)
                        {
                            if (m_coordinateFormat == CoordinateFormat.Rectangular)
                                return m_phaseDesignation + "r";
                            else
                                return m_phaseDesignation + "m";
                        }
                        break;
                    case SignalKind.Angle:
                        if (m_phaseDesignation != char.MinValue)
                        {
                            if (m_coordinateFormat == CoordinateFormat.Rectangular)
                                return m_phaseDesignation + "i";
                            else
                                return m_phaseDesignation + "a";
                        }
                        break;
                    case SignalKind.Frequency:
                        return "F";
                    case SignalKind.DfDt:
                        return "df";
                }

                return "";
            }
            set
            {
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    m_phaseDesignation = char.MinValue;
                    m_signalKind = SignalKind.Analog;
                    m_coordinateFormat = CoordinateFormat.Polar;
                }
                else
                {
                    if (string.Compare(value, "F", true) == 0)
                    {
                        m_phaseDesignation = char.MinValue;
                        m_signalKind = SignalKind.Frequency;
                        m_coordinateFormat = CoordinateFormat.Polar;
                    }
                    else if (string.Compare(value, "df", true) == 0)
                    {
                        m_phaseDesignation = char.MinValue;
                        m_signalKind = SignalKind.DfDt;
                        m_coordinateFormat = CoordinateFormat.Polar;
                    }
                    else if (value.Length > 1)
                    {
                        this.PhaseDesignation = value[0].ToString();
                        char component = char.ToLower(value[1]);

                        switch (component)
                        {
                            case 'r':
                                m_signalKind = SignalKind.Magnitude;
                                m_coordinateFormat = CoordinateFormat.Rectangular;
                                break;
                            case 'i':
                                m_signalKind = SignalKind.Angle;
                                m_coordinateFormat = CoordinateFormat.Rectangular;
                                break;
                            case 'm':
                                m_signalKind = SignalKind.Magnitude;
                                m_coordinateFormat = CoordinateFormat.Polar;
                                break;
                            case 'a':
                                m_signalKind = SignalKind.Angle;
                                m_coordinateFormat = CoordinateFormat.Polar;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        m_phaseDesignation = char.MinValue;
                        m_signalKind = SignalKind.Analog;
                        m_coordinateFormat = CoordinateFormat.Polar;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets phase designation of this <see cref="AnalogChannel"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Value is not a valid phase designation.</exception>
        public string PhaseDesignation
        {
            get
            {
                return m_phaseDesignation.ToString();
            }
            set
            {
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    m_phaseDesignation = char.MinValue;
                }
                else
                {
                    char phaseDesignation = char.ToUpper(value[0]);

                    if (m_validPhaseDesignations.BinarySearch(phaseDesignation) < 0)
                        throw new ArgumentException(value + " is not a valid phase designation.");

                    switch (phaseDesignation)
                    {
                        case 'A':
                        case 'R':
                        case '1':
                            m_phaseDesignation = 'A';
                            break;
                        case 'B':
                        case 'S':
                        case '2':
                            m_phaseDesignation = 'B';
                            break;
                        case 'C':
                        case 'T':
                        case '3':
                            m_phaseDesignation = 'C';
                            break;
                        case 'P':
                        case '+':
                            m_phaseDesignation = '+';
                            break;
                        case 'N':
                        case '-':
                            m_phaseDesignation = '-';
                            break;
                        case 'Z':
                        case '0':
                            m_phaseDesignation = '0';
                            break;
                        default:
                            m_phaseDesignation = char.MinValue;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets signal kind of this <see cref="AnalogChannel"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Value is not a valid analog signal kind.</exception>
        public SignalKind SignalKind
        {
            get
            {
                return m_signalKind;
            }
            set
            {
                if (m_validAnalogSignalKinds.BinarySearch(value) < 0)
                    throw new ArgumentException(value + " is not a valid analog signal kind.");

                m_signalKind = value;
            }
        }

        /// <summary>
        /// Gets or sets coordinate format of this <see cref="AnalogChannel"/>.
        /// </summary>
        public CoordinateFormat CoordinateFormat
        {
            get
            {
                return m_coordinateFormat;
            }
            set
            {
                m_coordinateFormat = value;
            }
        }

        #endregion

        #region [ Methods ]

        #endregion

        #region [ Operators ]

        #endregion

        #region [ Static ]

        // Static Fields

        // Static Constructor

        // Static Properties

        // Static Methods

        #endregion
        
    }
}
