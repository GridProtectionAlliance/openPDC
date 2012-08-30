//*******************************************************************************************************
//  Commands.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: James R Carroll
//      Office: PSO TRAN & REL, CHATTANOOGA - MR BK-C
//       Phone: 423/751-4165
//       Email: jrcarrol@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  05/01/2009 - James R Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

namespace MacrodyneController
{
    /// <summary>
    /// Macrodyne data input commands enumeration.
    /// </summary>
    public enum DataInputCommand : byte
    {
        ///// <summary>
        ///// Send reference phasor.
        ///// </summary>
        ///// <remarks>Command must be followed by phasor and xor checksum <see cref="Byte"/>.</remarks>
        //SendReferencePhasor = 0xA0,
        /// <summary>
        /// Send word data.
        /// </summary>
        /// <remarks>Command must be followed by big-endian <see cref="UInt16"/> and xor checksum <see cref="Byte"/></remarks>
        SendWordData = 0xA2,
        /// <summary>
        /// Send unit ID data.
        /// </summary>
        /// <remarks>Command must be followed by 8 ASCII bytes of data and xor checksum <see cref="Byte"/></remarks>
        SendUnitIdData = 0xA4,
        /// <summary>
        /// Send byte data.
        /// </summary>
        /// <remarks>Command must be followed by <see cref="Byte"/> data and xor checksum <see cref="Byte"/>.</remarks>
        SendByteData = 0xA6
    }

    /// <summary>
    /// Macrodyne set and request commands enumeration.
    /// </summary>
    /// <remarks>
    /// These commands should be transmitted in big-endian to make sure high word and low word are in the expected order.
    /// </remarks>
    public enum DeviceCommand : ushort
    {
        #region [ Set Commands ]

        /// <summary>
        /// Select Event 1.
        /// </summary>
        SelectEvent1 = 0xCC20,
        /// <summary>
        /// Select Event 2.
        /// </summary>
        SelectEvent2 = 0xCC21,
        /// <summary>
        /// Select Event 3.
        /// </summary>
        SelectEvent3 = 0xCC22,
        /// <summary>
        /// Select Event 4.
        /// </summary>
        SelectEvent4 = 0xCC23,
        /// <summary>
        /// Select Event 5.
        /// </summary>
        SelectEvent5 = 0xCC24,
        /// <summary>
        /// Select Event 6.
        /// </summary>
        SelectEvent6 = 0xCC25,
        /// <summary>
        /// Select Event 7.
        /// </summary>
        SelectEvent7 = 0xCC26,
        /// <summary>
        /// Select Event 8.
        /// </summary>
        SelectEvent8 = 0xCC27,
        /// <summary>
        /// Select Event 9.
        /// </summary>
        SelectEvent9 = 0xCC28,
        /// <summary>
        /// Select Event 10.
        /// </summary>
        SelectEvent10 = 0xCC29,
        /// <summary>
        /// Select Event 11.
        /// </summary>
        SelectEvent11 = 0xCC2A,
        /// <summary>
        /// Select Event 12.
        /// </summary>
        SelectEvent12 = 0xCC2B,
        /// <summary>
        /// Select Event 13.
        /// </summary>
        SelectEvent13 = 0xCC2C,
        /// <summary>
        /// Select Event 14.
        /// </summary>
        SelectEvent14 = 0xCC2D,
        /// <summary>
        /// Select Event 15.
        /// </summary>
        SelectEvent15 = 0xCC2E,
        /// <summary>
        /// Select Event 16.
        /// </summary>
        SelectEvent16 = 0xCC2F,
        /// <summary>
        /// Erase selected event.
        /// </summary>
        EraseSelectedEvent = 0xCC30,
        /// <summary>
        /// Force an event.
        /// </summary>
        ForceEvent = 0xCC32,
        /// <summary>
        /// Set the 1 second table pre-trigger to the value in the word buffer.
        /// </summary>
        SetOneSecondPreTriggerValue = 0xCC34,
        /// <summary>
        /// Set the extended table pre-trigger to the value in the word buffer.
        /// </summary>
        SetExtendedPreTriggerValue = 0xCC36,
        /// <summary>
        /// Set the unit ID (8 ASCII bytes) to the values in the 8 byte buffer (set using <see cref="DataInputCommand.SendUnitIDData"/>.
        /// </summary>
        SetUnitID = 0xCC38,
        /// <summary>
        /// Start sending ON-LINE data down this port (the port the command was received on).
        /// </summary>
        StartOnlineData = 0xCC3A,
        /// <summary>
        /// Stop sending ON-LINE data or reference data down this port.
        /// </summary>
        StopOnlineData = 0xCC3C,
        /// <summary>
        /// Start sending the reference down port1.
        /// </summary>
        /// <remarks>Disable the reference before enabling reference on the other port using the command <see cref="DeviceCommand.StopSendingReference"/>.</remarks>
        StartSendingReferencePort1 = 0xCC3E,
        /// <summary>
        /// Start sending the reference down port2.
        /// </summary>
        /// <remarks>Disable the reference before enabling reference on the other port using the command <see cref="DeviceCommand.StopSendingReference"/>.</remarks>
        StartSendingReferencePort2 = 0xCC40,
        /// <summary>
        /// Stop sending the reference down either port.
        /// </summary>
        StopSendingReference = 0xCC42,
        /// <summary>
        /// Enable the reference reception in any port.
        /// </summary>
        EnableReferenceReception = 0xCC44,
        /// <summary>
        /// Disable the reference reception in any port.
        /// </summary>
        DisableReferenceReception = 0xCC46,
        /// <summary>
        /// Re-boot the PMU code from the EEPROM and re-start the unit.
        /// </summary>
        RebootUnit = 0xCC48,
        /// <summary>
        /// Reset the unit and reset  the flags.
        /// </summary>
        ResetUnitAndFlags = 0xCC4A,
        /// <summary>
        /// Set the output rate to 2 cycles (i.e. 30 times/sec).
        /// </summary>
        Set2CycleOutputRate = 0xCC4C,
        /// <summary>
        /// Set the output rate to 5 cycles (i.e. 12 times/sec).
        /// </summary>
        Set5CycleOutputRate = 0xCC4E,
        /// <summary>
        /// Set the output rate to 10 cycles (i.e. 6 times/sec).
        /// </summary>
        Set10CycleOutputRate = 0xCC50,
        /// <summary>
        /// Set the PMU for 5 phasors.
        /// </summary>
        Use5Phasors = 0xCC52,
        /// <summary>
        /// Set the PMU for 4 phasors.
        /// </summary>
        Use4Phasors = 0xCC54,
        /// <summary>
        /// Set the PMU for 3 phasors.
        /// </summary>
        Use3Phasors = 0xCC56,
        /// <summary>
        /// Set the PMU for 2 phasors.
        /// </summary>
        Use2Phasors = 0xCC58,
        /// <summary>
        /// Set the PMU for 1 phasor.
        /// </summary>
        Use1Phasor = 0xCC5A,
        /// <summary>
        /// Set mscale to the value in the word buffer.
        /// </summary>
        SetMScaleValue = 0xCC5C,
        /// <summary>
        /// Enable all triggers.
        /// </summary>
        EnableAllTriggers = 0xCC5E,
        /// <summary>
        /// Disable all triggers.
        /// </summary>
        DisableAllTriggers = 0xCC60,
        /// <summary>
        /// Set the VMIN trigger to the value in the word buffer.
        /// </summary>
        SetVMinTrigger = 0xCC62,
        /// <summary>
        /// Set the VMAX trigger to the value in the word buffer.
        /// </summary>
        SetVMaxTrigger = 0xCC64,
        /// <summary>
        /// Set the ANGD trigger to the value in the word buffer.
        /// </summary>
        SetAngdTrigger = 0xCC66,
        /// <summary>
        /// Set the FREQ trigger to the value in  the word buffer.
        /// </summary>
        SetFreqTrigger = 0xCC68,
        /// <summary>
        /// Set the DFDT trigger to the value in the word buffer.
        /// </summary>
        SetDfDtTrigger = 0xCC6A,
        /// <summary>
        /// Set the LNCM trigger to the value in the word buffer.
        /// </summary>
        SetLncmTrigger = 0xCC6C,
        /// <summary>
        /// Set the VCOEF value to the value in the word buffer.
        /// </summary>
        SetVCoefValue = 0xCC6E,
        /// <summary>
        /// Set the FCOEF value to the value in the word buffer.
        /// </summary>
        SetFCoefValue = 0xCC70,
        /// <summary>
        /// Set the DCOEF value to the value in the word buffer.
        /// </summary>
        SetDCoefValue = 0xCC72,
        /// <summary>
        /// Set the NRM_DIG (normal state of digital channel) to the value in the word buffer.
        /// </summary>
        SetNrmDigState = 0xCC74,
        /// <summary>
        /// Set the DIG_ENB (digital channel trigger enable) to the value in the word buffer.
        /// </summary>
        SetDigEnbTrigger = 0xCC76,
        /// <summary>
        /// Reset the ON-LINE data format to the default setting.
        /// </summary>
        ResetOnlineDataFormat = 0xCC78,
        /// <summary>
        /// Add the second status byte to the ON-LINE data.
        /// </summary>
        AddSecondStatus = 0xCC7A,
        /// <summary>
        /// Add the time stamp to the ON-LINE data.
        /// </summary>
        AddTimeStamp = 0xCC7C,
        /// <summary>
        /// Add the second phasor to the ON-LINE data.
        /// </summary>
        AddSecondPhasor = 0xCC7E,
        /// <summary>
        /// Add the third phasor to the ON-LINE data.
        /// </summary>
        AddThirdPhasor = 0xCC80,
        /// <summary>
        /// Add the fourth phasor to the ON-LINE data.
        /// </summary>
        AddForthPhasor = 0xCC82,
        /// <summary>
        /// Add the fifth phasor to the ON-LINE data.
        /// </summary>
        AddFifthPhasor = 0xCC84,
        /// <summary>
        /// Add the reference phasor to the ON-LINE data.
        /// </summary>
        AddReferencePhasor = 0xCC86,
        /// <summary>
        /// Set the VMIN operational limit to the value  in the byte buffer.
        /// </summary>
        SetVMinOperationalLimit = 0xCC88,
        /// <summary>
        /// Set the VMAX operational limit to the value in the byte buffer.
        /// </summary>
        SetVMaxOperationalLimit = 0xCC8A,
        /// <summary>
        /// Set the ANGD operational limit to the value in the byte buffer.
        /// </summary>
        SetAngdOperationalLimit = 0xCC8C,
        /// <summary>
        /// Set the FREQ operational limit to the value in the byte buffer.
        /// </summary>
        SetFreqOperationalLimit = 0xCC8E,
        /// <summary>
        /// Set the DFDT operational limit to the value in the byte buffer.
        /// </summary>
        SetDfDtOperationalLimit = 0xCC90,
        /// <summary>
        /// Set the LNCM operational limit to the value in the byte buffer.
        /// </summary>
        SetLncmOperationalLimit = 0xCC92,
        /// <summary>
        /// Set the digital channels operational limit to the value in the byte buffer.
        /// </summary>
        SetDigitalOperationalLimit = 0xCC94,
        /// <summary>
        /// Reset all operational limit counters (ANALOG AND DIGITAL) to 0.
        /// </summary>
        ResetOperationalLimitCounters = 0xCC96,
        /// <summary>
        /// Add digital channels to the ON-LINE data.
        /// </summary>
        AddDigitals = 0xCC98,
        /// <summary>
        /// Set the first set of analog channels to the value in the word buffer which designates what each channel will be, VOLTAGE or CURRENT.
        /// </summary>
        SetPhasorType = 0xCC9A,
        /// <summary>
        /// Set GPS to transparent mode (host port A only).
        /// </summary>
        /// <remarks>NOTE: This command is NOT functional (per Macrodyne 1690M Operation Manual, v1.67).</remarks>
        SetGpsTransparentMode = 0xCC9C,
        /// <summary>
        /// Send this command when the following command refers to the second board.
        /// </summary>
        SendCommandToSecondBoard = 0xCC9E,
        /// <summary>
        /// Set the number of Digital Channels to 16.
        /// </summary>
        SetDigitalsTo16 = 0xCCA0,
        /// <summary>
        /// Set the number of Digital Channels to 32.
        /// </summary>
        SetDigitalsTo32 = 0xCCA2,
        /// <summary>
        /// Set Raw data pretrigger to the value in the word buffer.
        /// </summary>
        SetRawPreTriggerValue = 0xCCA4,
        /// <summary>
        /// Start Debug Mode. Stops PMU program and enters the debugger.
        /// </summary>
        StartDebugMode = 0xCCA6,

        #endregion

        #region [ Request Commands ]

        /// <summary>
        /// Request STATU1 flag (1 response byte).
        /// </summary>
        RequestStatus1Flags = 0xBB20,
        /// <summary>
        /// Request STATU2 flag (1 response byte).
        /// </summary>
        RequestStatus2Flags = 0xBB22,
        /// <summary>
        /// Request ON-LINE data format (2 response bytes).
        /// </summary>
        RequestOnlineDataFormat = 0xBB24,
        /// <summary>
        /// Request operational limit reached flags (3 response bytes).
        /// </summary>
        RequestOperationalLimitFlags = 0xBB26,
        /// <summary>
        /// Request value in word buffer (2 response bytes).
        /// </summary>
        RequestWordBufferValue = 0xBB28,
        /// <summary>
        /// Request value in byte buffer (1 response byte).
        /// </summary>
        RequestByteBufferValue = 0xBB2A,
        /// <summary>
        /// Request current time tag string (6 response bytes).
        /// </summary>
        RequestTimeTagValue = 0xBB2C,
        /// <summary>
        /// Request unit status.
        /// </summary>
        RequestUnitStatus = 0xBB2E,
        /// <summary>
        /// Request analog trigger values (18 response bytes).
        /// </summary>
        RequestAnalogTriggerValues = 0xBB30,
        /// <summary>
        /// Request VMIN trigger value (2 response bytes).
        /// </summary>
        RequestVMinTriggerValue = 0xBB32,
        /// <summary>
        /// Request VMAX trigger value (2 response bytes).
        /// </summary>
        RequestVMaxTriggerValue = 0xBB34,
        /// <summary>
        /// Request ANGD trigger value (2 response bytes).
        /// </summary>
        RequestAngdTriggerValue = 0xBB36,
        /// <summary>
        /// Request FREQ trigger value (2 response bytes).
        /// </summary>
        RequestFreqTriggerValue = 0xBB38,
        /// <summary>
        /// Request DFDT trigger value (2 response bytes).
        /// </summary>
        RequestDfDtTriggerValue = 0xBB3A,
        /// <summary>
        /// Request LNCM trigger value (2 response bytes).
        /// </summary>
        RequestLncmTriggerValue = 0xBB3C,
        /// <summary>
        /// Request VCOEF trigger value (2 response bytes).
        /// </summary>
        RequestVCoefTriggerValue = 0xBB3E,
        /// <summary>
        /// Request FCOEF trigger value (2 response bytes).
        /// </summary>
        RequestFCoefTriggerValue = 0xBB40,
        /// <summary>
        /// Request DCOEF trigger value (2 response bytes).
        /// </summary>
        RequestDCoefTriggerValue = 0xBB42,
        /// <summary>
        /// Request normal state of digital channels (2 response bytes).
        /// </summary>
        RequestDigitalsNormalState = 0xBB44,
        /// <summary>
        /// Request trigger enabled state of digital channels (1 response byte).
        /// </summary>
        RequestDigitalsTriggerEnabledState = 0xBB46,
        /// <summary>
        /// Request value in unit ID buffer (8 ASCII response bytes).
        /// </summary>
        RequestUnitIDBufferValue = 0xBB48,
        /// <summary>
        /// Request the value which determines what each analog channel is, bit # = channel #, 1 = VOLTAGE, 0 = CURRENT.
        /// </summary>
        // TODO: Since this is useful, determine how many bytes are in response - I suspect two since there are 10 possible phasors - this is not clearly documented
        RequestPhasorType = 0xBB4A,
        /// <summary>
        /// Request table line from 1 second table.
        /// </summary>
        RequestOneSecondTableLine = 0xBB4C,
        /// <summary>
        /// Request table line from extended table.
        /// </summary>
        RequestExtendedTableLine = 0xBB4E,
        /// <summary>
        /// Request previous table line/block.
        /// </summary>
        RequestPreviousTableLine = 0xBB50,
        /// <summary>
        /// Request time information for selected table.
        /// </summary>
        RequestTableTimeInformation = 0xBB52,
        /// <summary>
        /// Request trigger information for selected table.
        /// </summary>
        RequestTableTriggerInformation = 0xBB54,
        /// <summary>
        /// Request table with freeze reason (16 response bytes).
        /// </summary>
        RequestTableWithFreezeReason = 0xBB56,
        /// <summary>
        /// Request number of bytes in time of freeze tables (1 response byte).
        /// </summary>
        RequestTimeOfFreezeTableSize = 0xBB58,
        /// <summary>
        /// Request time of freeze tables.
        /// </summary>
        RequestTimeOfFreezeTables = 0xBB5A,
        /// <summary>
        /// Request value of operational limits (7 response bytes).
        /// </summary>
        RequestOperationalLimitsValue = 0xBB5C,
        /// <summary>
        /// Request value of operational counters (6 response bytes).
        /// </summary>
        RequestOperationalCountersValue = 0xBB5E,
        /// <summary>
        /// Request value of operational counts of digital channels (16 response bytes).
        /// </summary>
        RequestOperationalDigitalCountsValue = 0xBB60,
        /// <summary>
        /// Request raw table line.
        /// </summary>
        RequestRawTableLine = 0xBB62,
        /// <summary>
        /// Request raw table information (18 response bytes).
        /// </summary>
        RequestRawTableInformation = 0xBB64,
        /// <summary>
        /// Request current raw table pretrigger (22 response bytes).
        /// </summary>
        RequestCurrentRawTablePreTrigger = 0xBB66,

        #endregion
    }
}
