using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Sys
{
    public class SysInmatning
    {
        public static bool StringKontroll(out string newVariable, int kontrollVal)
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
                            newVariable = Console.ReadLine();
                            newVariable.Trim().ToLower();

                            if (string.IsNullOrWhiteSpace(newVariable.Trim().ToLower()))
                            {
                                Console.WriteLine("Fel inmatning, vänligen gilglig titel: ");
                            }
                            else
                            {
                                return true;
                            }
                        }

                    case 2: // Författare input
                        while (true)
                        {
                            Console.WriteLine("Vänligen skriv författarens namn: ");
                            newVariable = Console.ReadLine();
                            newVariable.Trim().ToLower();

                            if (string.IsNullOrWhiteSpace(newVariable.Trim().ToLower()))
                            {
                                Console.WriteLine("Fel inmatning, vänligen skriv giltlig författare: ");
                            }
                            else
                            {
                                return true;
                            }
                        }

                    case 3: // namn (LånTagare m.m.) input
                        while (true)
                        {
                            Console.WriteLine("Vänligen skriv in låntagarenns namn: ");
                            newVariable = Console.ReadLine();
                            newVariable.Trim().ToLower();

                            if (string.IsNullOrWhiteSpace(newVariable))
                            {
                                Console.WriteLine("Fel inmatning, vänligen skriv giltlig namn: ");
                            }
                            else
                            {
                                return true;
                            }
                        }

                    case 4:
                        while (true)
                        {
                            Console.Clear();

                            Console.WriteLine("Vänligen skriv in Bok-ID: ");
                            newVariable = Console.ReadLine();
                            newVariable.Trim();

                            bool readSuccess = int.TryParse(newVariable.Trim(), out int integer);
                            if (!readSuccess)
                            {
                                Console.WriteLine("Vänligen skriv in ett giltlig Bok-ID");
                            }
                            else
                            {
                                return true; 
                            }
                        }
                }
            }
        }
    }
}
