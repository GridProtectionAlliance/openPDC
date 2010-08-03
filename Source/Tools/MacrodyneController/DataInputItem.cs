using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVA.PhasorProtocols.Macrodyne;

namespace MacrodyneController
{
    public class DataInputItem
    {
        private DataInputCommand m_command;

        public DataInputItem(DataInputCommand command)
        {
            m_command = command;
        }

        public DataInputCommand Command
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
            return Enum.GetName(typeof(DataInputCommand), m_command).ToFormattedEnumName();
        }
    }
}
