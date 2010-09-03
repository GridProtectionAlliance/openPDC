using System;
using System.Text;
using System.Windows.Forms;

namespace MacrodyneController
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MacrodyneController());
        }

        /// <summary>
        /// Formats an enumeration name for visual display.
        /// </summary>
        /// <param name="name">Enumeration field name to format.</param>
        /// <returns>Formatted enumeration name for visual display.</returns>
        static public string ToFormattedEnumName(this string name)
        {
            StringBuilder image = new StringBuilder();
            char[] chars = name.ToCharArray();
            char letter;

            for (int i = 0; i < chars.Length; i++)
            {
                letter = chars[i];

                // Create word spaces at every capital letter
                if (Char.IsUpper(letter) && image.Length > 0)
                {
                    // Test for "ID" sequence exception
                    if (i < chars.Length - 1 && letter == 'I')
                    {
                        if (chars[i + 1] == 'D')
                        {
                            image.Append(" ID");
                            i++;
                        }
                        else
                        {
                            image.Append(' ');
                            image.Append(letter);
                        }
                    }
                    else
                    {
                        image.Append(' ');
                        image.Append(letter);
                    }
                }
                else
                    image.Append(letter);
            }

            return image.ToString();
        }
    }
}
