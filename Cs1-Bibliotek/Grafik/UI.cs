using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Grafik
{
    public class UI
    {
        public static void HuvudMeny()
        {
            Console.Clear();
            Console.WriteLine("""
                ==============================================
                                  BIBLIOTEK
                                    MENY

                [1] - Sök i biblioteket

                [2] - Redigera Boklista

                [3] - Avsluta

                ==============================================
                """);
        }

        public static void Meny1()
        {
            Console.Clear();
            Console.WriteLine("""
                ==============================================
                               SÖK I BIBLIOTEK
                                    MENY

                [1] - Sök via ID

                [2] - Visa alla registrerade böcker

                [3] - Bakåt

                ==============================================
                """);
        }

        public static void Meny2()
        {
            Console.Clear();
            Console.WriteLine("""
                ==============================================
                              REDIGERA BOKLISTA
                                    MENY

                [1] - Sök i biblioteket

                [2] - Registrera ny bok

                [3] - Bakåt

                ==============================================
                """);
        }

        public static int ValSiffra(int min, int max)
        {
            while (true) // Jag tvingar tills jag får en giltlig input
            {
                if (!int.TryParse(Console.ReadLine(), out int input) || input < min || input > max)
                {
                    Console.WriteLine($"försök igen, välj mellan {min} och {max}");
                }
                else
                    return input;
            }

        }
    }
}
