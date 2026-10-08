using Cs1_Bibliotek.Models;
using Cs1_Bibliotek.Services;
using System;
using System.Collections.Generic;
using System.Text;


namespace Cs1_Bibliotek.Grafik
{
    public class UI
    {

        public static void Start()
        {
            // -------------------------  KOD -----------------------------
            bool isRunning = true;
            while (isRunning) // för att kunna använda continue i switch-cases
            {
                Grafik.UI.HuvudMeny();
                int valSiffra = Grafik.UI.ValSiffra(1, 3);
                switch (valSiffra)
                {
                    case 1:
                        Grafik.UI.Meny1();
                        valSiffra = Grafik.UI.ValSiffra(1, 3);
                        switch (valSiffra)
                        {
                            case 1:
                                // Hämta med id
                                
                                break;

                            case 2:
                                // Visa alla registrerade böcker

                                break;

                            case 3: // backa
                                continue;
                        }
                        break;

                    case 2:
                        Grafik.UI.Meny2();
                        valSiffra = Grafik.UI.ValSiffra(1, 3);
                        switch (valSiffra)
                        {
                            case 1:
                                // sök i bibliotek via sträng
                                break;

                            case 2:
                                // Registrera ny bok
                                break;

                            case 3: // backa
                                continue;
                        }
                        break;

                    case 3:
                        isRunning = false;
                        break;
                }
            }
        }
        }
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
