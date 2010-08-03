using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVA.PhasorProtocols.Macrodyne;

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
            return Enum.GetName(typeof(DeviceCommand), m_command).ToFormattedEnumName();
        }
    }
}
