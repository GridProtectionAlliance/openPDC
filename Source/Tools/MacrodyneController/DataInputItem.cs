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
            StringBuilder image = new StringBuilder();

            foreach (char letter in Enum.GetName(typeof(DataInputCommand), m_command))
            {
                if (Char.IsUpper(letter) && image.Length > 0)
                {
                    image.Append(' ');
                    image.Append(letter);
                }
                else
                    image.Append(letter);
            }

            return image.ToString();
        }
    }
}
