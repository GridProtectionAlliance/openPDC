'*******************************************************************************************************
'  ApplicationSettings.vb - Gbtc
'
'  Tennessee Valley Authority, 2009
'  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
'
'  This software is made freely available under the TVA Open Source Agreement (see below).
'
'  Code Modification History:
'  -----------------------------------------------------------------------------------------------------
'  02/13/2007 - J. Ritchie Carroll
'       Initial version of source generated.
'  09/15/2009 - Stephen C. Wills
'       Added new header and license agreement.
'
'*******************************************************************************************************

#Region " TVA Open Source Agreement "

' THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
' MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
' TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
' ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
' DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
' MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
' ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

' Original Software Designation: openPDC
' Original Software Title: The TVA Open Source Phasor Data Concentrator
' User Registration Requested. Please Visit https://naspi.tva.com/Registration/
' Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

' 1. DEFINITIONS

' A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
' that makes a Modification.

' B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
' the use or sale of its Modification alone or when combined with the Subject Software.

' C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
' image, or any other device.

' D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
' another.

' E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
' software separate from the Subject Software that is not governed by the terms of this Agreement.

' F. "Modification" means any alteration of, including addition to or deletion from, the substance or
' structure of either the Original Software or Subject Software, and includes derivative works, as that
' term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
' as part of a Larger Work does not in and of itself constitute a Modification.

' G. "Original Software" means the computer software first released under this Agreement by Government
' Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

' H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
' Contributors.

' I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

' J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

' K. "Sale" means the exchange of the Subject Software for money or equivalent value.

' L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

' M. "Use" means the application or employment of the Subject Software for any purpose.

' 2. GRANT OF RIGHTS

' A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
' with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
' non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
' the Subject Software:

' 1. Use

' 2. Distribution

' 3. Reproduction

' 4. Modification

' 5. Redistribution

' 6. Display

' B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
' respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
' Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
' pertaining to the Subject Software:

' 1. Use

' 2. Distribution

' 3. Reproduction

' 4. Sale

' 5. Offer for Sale

' C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
' and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
' such Modification causes the combination to be covered by the Covered Patents. It does not apply to
' any other combinations that include a Modification. 

' D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
' Such sublicense must be under the same terms and conditions of this Agreement.

' 3. OBLIGATIONS OF RECIPIENT

' A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
' additions covered under paragraph 3H. 

' 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
' must be included with each copy of the Subject Software; and

' 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
' Recipient must also make the source code freely available, and must provide with each copy of the
' Subject Software information on how to obtain the source code in a reasonable manner on or through a
' medium customarily used for software exchange.

' B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
' Software:

'          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

' C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
' must identify itself as the originator of its Modification in a manner that reasonably allows
' subsequent Recipients to identify the originator of the Modification. In fulfillment of these
' requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
' made and the date of the alterations, identifies Contributor as originator of the alterations, and
' consents to characterization of the alterations as a Modification, for example, by including a
' statement that the Modification is derived, directly or indirectly, from Original Software provided by
' Government Agency. Once consent is granted, it may not thereafter be revoked.

' D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
' been added to the Subject Software, a Recipient may not remove it without the express permission of
' the Contributor who added the notice.

' E. A Recipient may not make any representation in the Subject Software or in any promotional,
' advertising or other material that may be construed as an endorsement by Government Agency or by any
' prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
' advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

' F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
' upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
' following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
' shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
' requested that the Recipient inform Government Agency at the web site provided above how to access the
' Modification.

' G. Each Contributor represents that that its Modification does not violate any existing agreements,
' regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
' conveyed by this Agreement.

' H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
' liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
' however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
' Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
' obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
' Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
' indemnity and/or liability offered by such Recipient.

' I. A Recipient may create a Larger Work by combining Subject Software with separate software not
' governed by the terms of this agreement and distribute the Larger Work as a single product. In such
' case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
' is subject to this Agreement.

' J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
' any goods or technical data from the United States may require some form of export license from the
' U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
' U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
' required, it shall be issued. Nothing granted herein provides any such export license.

' 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

' A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
' EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
' SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
' PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
' FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
' AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
' RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
' RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
' LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
' "AS IS."

' B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
' AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
' OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
' SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
' SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
' EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
' LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
' EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
' GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
' IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

' 5. GENERAL TERMS

' A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
' Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
' thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
' immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
' Software properly granted by the breaching Recipient shall survive any such termination of this
' Agreement.

' B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
' it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

' C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
' including, but not limited to, determining the validity of this Agreement, the meaning of its
' provisions and the rights, obligations and remedies of the parties.

' D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
' parties relating to release of the Subject Software and may not be superseded, modified or amended
' except by further written agreement duly executed by the parties.

' E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
' affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
' Recipient hereby agrees to all terms and conditions herein.

' F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
' representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

#End Region

Imports System.Text
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports TVA.Configuration

Public Class ApplicationSettings

    Inherits CategorizedSettingsBase

#Region " Default Setting Values "

    ' Default application settings
    Private Const DefaultMaximumConnectionAttempts As Integer = 1
    Private Const DefaultAutoStartDataParsingSequence As Boolean = True
    Private Const DefaultExecuteParseOnSeparateThread As Boolean = False
    Private Const DefaultMaximumFrameDisplayBytes As Integer = 128
    Private Const DefaultRestoreLastConnectionSettings As Boolean = True
    Private Const DefaultForceIPv4 As Boolean = False

    ' Default attribute tree settings
    Private Const DefaultChannelNodeBackgroundColor As String = "Yellow"
    Private Const DefaultChannelNodeForegroundColor As String = "Black"
    Private Const DefaultInitialNodeState As String = "Collapsed"
    Private Const DefaultShowAttributesAsChildren As Boolean = True

    ' Default general chart settings
    Private Const DefaultChartRefreshRate As Single = 0.1
    Private Const DefaultBackgroundColor As String = "White"
    Private Const DefaultForegroundColor As String = "Navy"
    Private Const DefaultTrendLineWidth As Integer = 4
    Private Const DefaultShowDataPointsOnGraphs As Boolean = False

    ' Default phase angle graph settings
    Private Const DefaultPhaseAngleGraphStyle As String = "Relative"
    Private Const DefaultShowPhaseAngleLegend As Boolean = True
    Private Const DefaultPhaseAnglePointsToPlot As Integer = 30
    Private Const DefaultLegendBackgroundColor As String = "AliceBlue"
    Private Const DefaultLegendForegroundColor As String = "Navy"
    Private Const DefaultPhaseAngleColors As String = "Black;Red;Green;SteelBlue;DarkGoldenrod;Brown;Coral;Purple"

    ' Default frequency graph settings
    Private Const DefaultFrequencyPointsToPlot As Integer = 30
    Private Const DefaultFrequencyColor As String = "SteelBlue"

#End Region

#Region " Public Member Declarations "

    Public Event PhaseAngleColorsChanged()

    ' Configuration file categories
    Public Const ApplicationSettingsCategory As String = "Application Settings"
    Public Const AttributeTreeCategory As String = "Attribute Tree"
    Public Const ChartSettingsCategory As String = "Chart Settings"
    Public Const PhaseAngleGraphCategory As String = "Phase Angle Graph"
    Public Const FrequencyGraphCategory As String = "Frequency Graph"

    Public Enum AngleGraphStyle
        Raw
        Relative
    End Enum

    Public Enum NodeState
        Expanded
        Collapsed
    End Enum

#Region " Color List with Content Cleared Notification "

    Public Class ColorListTypeConverter

        Inherits TypeConverter

        Private m_colorParser As New ColorConverter

        Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean

            If sourceType Is GetType(String) Then Return True
            Return MyBase.CanConvertFrom(context, sourceType)

        End Function

        Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object

            If TypeOf value Is String Then
                Dim colors As New ColorList

                For Each colorItem As String In CStr(value).Split(";"c)
                    colors.Add(CType(m_colorParser.ConvertFromString(colorItem.Trim()), Color))
                Next

                Return colors
            End If

            Return MyBase.ConvertFrom(context, culture, value)

        End Function

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object

            If destinationType Is GetType(String) Then
                With New StringBuilder
                    For Each colorItem As Color In CType(value, ColorList)
                        If .Length > 0 Then .Append(";"c)
                        .Append(m_colorParser.ConvertToString(colorItem))
                    Next

                    Return .ToString()
                End With
            End If

            Return MyBase.ConvertTo(context, culture, value, destinationType)

        End Function

    End Class

    ' This class exposes an event notification of when then list is cleared - this is really
    ' our only signal to know when a collection has been modified in the property grid

    <TypeConverter(GetType(ColorListTypeConverter))> _
    Public Class ColorList

        Inherits Collection(Of Color)

        Public Event ListContentCleared()

        Public Sub New(ByVal ParamArray colors As Color())

            For Each newColor As Color In colors
                Add(newColor)
            Next

        End Sub

        Protected Overrides Sub ClearItems()

            MyBase.ClearItems()
            RaiseEvent ListContentCleared()

        End Sub

    End Class

#End Region

#End Region

#Region " Private Member Declarations "

    ' Application settings
    Private m_maximumConnectionAttempts As Integer
    Private m_autoStartDataParsingSequence As Boolean
    Private m_executeParseOnSeparateThread As Boolean
    Private m_maximumFrameDisplayBytes As Integer
    Private m_restoreLastConnectionSettings As Boolean
    Private m_forceIPv4 As Boolean

    ' Attribute tree settings
    Private m_channelNodeBackgroundColor As Color
    Private m_channelNodeForegroundColor As Color
    Private m_initialNodeState As NodeState
    Private m_showAttributesAsChildren As Boolean

    ' General chart settings
    Private m_refreshRate As Single
    Private m_backgroundColor As Color
    Private m_foregroundColor As Color
    Private m_trendLineWidth As Integer
    Private m_showDataPointsOnGraphs As Boolean

    ' Phase angle graph settings
    Private m_phaseAngleGraphStyle As AngleGraphStyle
    Private m_showPhaseAngleLegend As Boolean
    Private m_phaseAnglePointsToPlot As Integer
    Private m_legendBackgroundColor As Color
    Private m_legendForegroundColor As Color
    Private WithEvents m_phaseAngleColors As ColorList

    ' Frequency graph settings
    Private m_frequencyPointsToPlot As Integer
    Private m_frequencyColor As Color

    ' Other members
    Private WithEvents m_eventDelayTimer As Timers.Timer

#End Region

#Region " Constructors "

    Public Sub New()

        ' Specifiy default category
        MyBase.New("General")

        m_eventDelayTimer = New Timers.Timer

        With m_eventDelayTimer
            .Interval = 250
            .AutoReset = False
            .Enabled = False
        End With

    End Sub

#End Region

#Region " Application Settings "

    <Category(ApplicationSettingsCategory), _
    Description("Maximum number of times to attempt connection before giving up; set to -1 to continue connection attempt indefinitely."), _
    DefaultValue(DefaultMaximumConnectionAttempts)> _
    Public Property MaximumConnectionAttempts() As Integer
        Get
            Return m_maximumConnectionAttempts
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                m_maximumConnectionAttempts = -1
            ElseIf value > 0 Then
                m_maximumConnectionAttempts = value
            Else
                m_maximumConnectionAttempts = DefaultMaximumConnectionAttempts
            End If
        End Set
    End Property

    <Category(ApplicationSettingsCategory), _
    Description("Set to True to automatically send commands for ConfigFrame2 and EnableRealTimeData."), _
    DefaultValue(DefaultAutoStartDataParsingSequence)> _
    Public Property AutoStartDataParsingSequence() As Boolean
        Get
            Return m_autoStartDataParsingSequence
        End Get
        Set(ByVal value As Boolean)
            m_autoStartDataParsingSequence = value
        End Set
    End Property

    <Category(ApplicationSettingsCategory), _
    Description("Allows frame parsing to be executed on a separate thread (other than communications thread) - typically only needed when data frames are very large.  This change will happen dynamically, even if a connection is active."), _
    DefaultValue(DefaultExecuteParseOnSeparateThread)> _
    Public Property ExecuteParseOnSeparateThread() As Boolean
        Get
            Return m_executeParseOnSeparateThread
        End Get
        Set(ByVal value As Boolean)
            m_executeParseOnSeparateThread = value
        End Set
    End Property

    <Category(ApplicationSettingsCategory), _
    Description("Maximum encoded bytes to display for frames in the ""Real-time Frame Detail""."), _
    DefaultValue(DefaultMaximumFrameDisplayBytes)> _
    Public Property MaximumFrameDisplayBytes() As Integer
        Get
            Return m_maximumFrameDisplayBytes
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                m_maximumFrameDisplayBytes = DefaultMaximumFrameDisplayBytes
            Else
                m_maximumFrameDisplayBytes = value
            End If
        End Set
    End Property

    <Category(ApplicationSettingsCategory), _
    Description("Set to True to load previous connection settings at startup."), _
    DefaultValue(DefaultRestoreLastConnectionSettings)> _
    Public Property RestoreLastConnectionSettings() As Boolean
        Get
            Return m_restoreLastConnectionSettings
        End Get
        Set(ByVal value As Boolean)
            m_restoreLastConnectionSettings = value
        End Set
    End Property

    <Category(ApplicationSettingsCategory), _
    Description("Set to True to force use of IPv4."), _
    DefaultValue(DefaultForceIPv4)> _
    Public Property ForceIPv4() As Boolean
        Get
            Return m_forceIPv4
        End Get
        Set(ByVal value As Boolean)
            m_forceIPv4 = value
        End Set
    End Property

#End Region

#Region " Attribute Tree Settings "

    <Category(AttributeTreeCategory), _
    Description("Defines the highlight background color for channel node entries on the attribute tree."), _
    DefaultValue(GetType(Color), DefaultChannelNodeBackgroundColor)> _
    Public Property ChannelNodeBackgroundColor() As Color
        Get
            Return m_channelNodeBackgroundColor
        End Get
        Set(ByVal value As Color)
            m_channelNodeBackgroundColor = value
        End Set
    End Property

    <Category(AttributeTreeCategory), _
    Description("Defines the highlight foreground color for channel node entries on the attribute tree."), _
    DefaultValue(GetType(Color), DefaultChannelNodeForegroundColor)> _
    Public Property ChannelNodeForegroundColor() As Color
        Get
            Return m_channelNodeForegroundColor
        End Get
        Set(ByVal value As Color)
            m_channelNodeForegroundColor = value
        End Set
    End Property

    <Category(AttributeTreeCategory), _
    Description("Defines the initial state for nodes when added to the attribute tree.  Note that a fully expanded tree will take much longer to initialize."), _
    DefaultValue(GetType(NodeState), DefaultInitialNodeState)> _
    Public Property InitialNodeState() As NodeState
        Get
            Return m_initialNodeState
        End Get
        Set(ByVal value As NodeState)
            m_initialNodeState = value
        End Set
    End Property

    <Category(AttributeTreeCategory), _
    Description("Set to True to show attributes as children of their channel entries."), _
    DefaultValue(DefaultShowAttributesAsChildren)> _
    Public Property ShowAttributesAsChildren() As Boolean
        Get
            Return m_showAttributesAsChildren
        End Get
        Set(ByVal value As Boolean)
            m_showAttributesAsChildren = value
        End Set
    End Property

#End Region

#Region " General Chart Settings "

    <Category(ChartSettingsCategory), _
    Description("Chart refresh rate in seconds. Typical setting is 0.1, increase this number if app runs slow."), _
    DefaultValue(DefaultChartRefreshRate)> _
    Public Property RefreshRate() As Single
        Get
            Return m_refreshRate
        End Get
        Set(ByVal value As Single)
            If value <= 0 Then
                m_refreshRate = DefaultChartRefreshRate
            Else
                m_refreshRate = value
            End If
        End Set
    End Property

    <Category(ChartSettingsCategory), _
    Description("Background color for graph region."), _
    DefaultValue(GetType(Color), DefaultBackgroundColor)> _
    Public Property BackgroundColor() As Color
        Get
            Return m_backgroundColor
        End Get
        Set(ByVal value As Color)
            m_backgroundColor = value
        End Set
    End Property

    <Category(ChartSettingsCategory), _
    Description("Foreground color for graph region (axes, legend border, text, etc.)"), _
    DefaultValue(GetType(Color), DefaultForegroundColor)> _
    Public Property ForegroundColor() As Color
        Get
            Return m_foregroundColor
        End Get
        Set(ByVal value As Color)
            m_foregroundColor = value
        End Set
    End Property

    <Category(ChartSettingsCategory), _
    Description("Trend line graphing width (in pixels)."), _
    DefaultValue(DefaultTrendLineWidth)> _
    Public Property TrendLineWidth() As Integer
        Get
            Return m_trendLineWidth
        End Get
        Set(ByVal value As Integer)
            If value <= 0 Then
                m_trendLineWidth = DefaultTrendLineWidth
            Else
                m_trendLineWidth = value
            End If
        End Set
    End Property

    <Category(ChartSettingsCategory), _
    Description("Set to True to show data points on graphs."), _
    DefaultValue(DefaultShowDataPointsOnGraphs)> _
    Public Property ShowDataPointsOnGraphs() As Boolean
        Get
            Return m_showDataPointsOnGraphs
        End Get
        Set(ByVal value As Boolean)
            m_showDataPointsOnGraphs = value
        End Set
    End Property

#End Region

#Region " Phase Angle Graph Settings "

    <Category(PhaseAngleGraphCategory), _
    Description("Sets the phase angle graph to plot either raw or relative phase angles."), _
    DefaultValue(GetType(AngleGraphStyle), DefaultPhaseAngleGraphStyle)> _
    Public Property PhaseAngleGraphStyle() As AngleGraphStyle
        Get
            Return m_phaseAngleGraphStyle
        End Get
        Set(ByVal value As AngleGraphStyle)
            m_phaseAngleGraphStyle = value
        End Set
    End Property

    <Category(PhaseAngleGraphCategory), _
    Description("Set to True to show phase angle graph legend."), _
    DefaultValue(DefaultShowPhaseAngleLegend)> _
    Public Property ShowPhaseAngleLegend() As Boolean
        Get
            Return m_showPhaseAngleLegend
        End Get
        Set(ByVal value As Boolean)
            m_showPhaseAngleLegend = value
        End Set
    End Property

    <Category(PhaseAngleGraphCategory), _
    Description("Sets the total number of phase angle points to display."), _
    DefaultValue(DefaultPhaseAnglePointsToPlot)> _
    Public Property PhaseAnglePointsToPlot() As Integer
        Get
            Return m_phaseAnglePointsToPlot
        End Get
        Set(ByVal value As Integer)
            If value < 2 Then
                m_phaseAnglePointsToPlot = DefaultPhaseAnglePointsToPlot
            Else
                m_phaseAnglePointsToPlot = value
            End If
        End Set
    End Property

    <Category(PhaseAngleGraphCategory), _
    Description("Background color for phase angle legend."), _
    DefaultValue(GetType(Color), DefaultLegendBackgroundColor)> _
    Public Property LegendBackgroundColor() As Color
        Get
            Return m_legendBackgroundColor
        End Get
        Set(ByVal value As Color)
            m_legendBackgroundColor = value
        End Set
    End Property

    <Category(PhaseAngleGraphCategory), _
    Description("Foreground color for phase angle legend text."), _
    DefaultValue(GetType(Color), DefaultLegendForegroundColor)> _
    Public Property LegendForegroundColor() As Color
        Get
            Return m_legendForegroundColor
        End Get
        Set(ByVal value As Color)
            m_legendForegroundColor = value
        End Set
    End Property

    <Category(PhaseAngleGraphCategory), _
    Description("Possible foreground colors for phase angle trends."), _
    DefaultValue(GetType(ColorList), DefaultPhaseAngleColors)> _
    Public Property PhaseAngleColors() As ColorList
        Get
            Return m_phaseAngleColors
        End Get
        Set(ByVal value As ColorList)
            m_phaseAngleColors = value
        End Set
    End Property

#End Region

#Region " Frequency Graph Settings "

    <Category(FrequencyGraphCategory), _
    Description("Sets the total number of frequency points to display."), _
    DefaultValue(DefaultFrequencyPointsToPlot)> _
    Public Property FrequencyPointsToPlot() As Integer
        Get
            Return m_frequencyPointsToPlot
        End Get
        Set(ByVal value As Integer)
            If value < 2 Then
                m_frequencyPointsToPlot = DefaultFrequencyPointsToPlot
            Else
                m_frequencyPointsToPlot = value
            End If
        End Set
    End Property

    <Category(FrequencyGraphCategory), _
    Description("Foreground color for frequency trend."), _
    DefaultValue(GetType(Color), DefaultFrequencyColor)> _
    Public Property FrequencyColor() As Color
        Get
            Return m_frequencyColor
        End Get
        Set(ByVal value As Color)
            m_frequencyColor = value
        End Set
    End Property

#End Region

#Region " Private Method Implementation "

    Private Sub m_phaseAngleColors_ListContentCleared() Handles m_phaseAngleColors.ListContentCleared

        ' Updates to a collection from a PropertyGrid don't get a normal "PropertyValueChanged" notification,
        ' so you're stuck with detecting a call to "Clear" in your personal collection.  However, the update
        ' is not complete until a call to "Add" for each updated item, so we need to wait for a moment to
        ' allow all of the adds to finish - this isn't exact science - someone didn't think through this one.
        m_eventDelayTimer.Enabled = True

    End Sub

    Private Sub m_eventDelayTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles m_eventDelayTimer.Elapsed

        RaiseEvent PhaseAngleColorsChanged()

    End Sub

#End Region

End Class
