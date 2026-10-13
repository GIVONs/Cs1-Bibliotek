using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Sys
{
    public class SysInmatning
    {
/*        public static bool StringKontroll(string input)
        {
            input.Trim().ToLower();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(input) || input.Equals("exit"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Fel inmatning, vänligen skriv bara text");
                    continue;
                }
            }

        }*/

        /// <summary>
        /// Gives a choice of what data-type input to check correctness for.
        /// </summary>
        /// <param name="kontrollVal">If 1: String, If 2: int, if 3: decimal.</param>
        /// <returns></returns>
        public static bool StringKontroll(out string input, int kontrollVal)
        {
            while (true)
            {
                Console.Clear();
                switch (kontrollVal)
                {
                    case 1: // Titel input: to not move from here untill correct
                        while (true)
                        {

                            Console.WriteLine("Vänligen skriv i titel: ");
                            input = Console.ReadLine();
                            input.Trim().ToLower();

                            if (string.IsNullOrWhiteSpace(input))
                            {
                                Console.WriteLine("Fel inmatning, vänligen gilglig namn: ");
                            }
                            else
                            {
                                return true;
                            }
                        }

                    case 2: // Författare input
                        while (true)
                        {
                            Console.WriteLine("Vänligen skriv i författare: ");
                            input = Console.ReadLine();
                            input.Trim().ToLower();

                            if (string.IsNullOrWhiteSpace(input))
                            {
                                Console.WriteLine("Fel inmatning, vänligen skriv giltlig text: ");
                            }
                            else
                            {
                                return true;
                            }
                        }

                    case 3: // decimal input
                        while (true)
                        {
                            Console.Clear();

                            Console.WriteLine("Vänligen skriv in i decimalform: ");
                            input = Console.ReadLine();
                            input.Trim().ToLower();

                            bool readSuccess = decimal.TryParse(input, out decimal decimalTal);
                            if (!readSuccess)
                            {
                                Console.WriteLine("Vänligen skriv in ett giltlig värde");
                                // Här finns ingen break eller return, så loopen fortsätter tills användaren skriver in ett giltigt värde eller EXIT.
                            }
                            else
                            {
                                return true; // Return tar oss ut ur loopen.
                            }
                        }
                }
            }
        }
    }
}
