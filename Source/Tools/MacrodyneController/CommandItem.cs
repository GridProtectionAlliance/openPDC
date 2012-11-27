using System;
using GSF;
using GSF.PhasorProtocols.Macrodyne;

namespace MacrodyneController
{
    public class CommandItem
    {
        private DeviceCommand m_command;

        public CommandItem(DeviceCommand command)
        {
            m_command = command;
        }

        public DeviceCommand Command
        {
            get
            {
                return m_command;
            }
            set
            {
                m_command = value;
            }
        }

        // Provide a formatted enumeration string
        public override string ToString()
        {
            return m_command.GetFormattedName();
        }
    }
}
