using Cs1_Bibliotek.DB;
using Cs1_Bibliotek.Models;
using Cs1_Bibliotek.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;


namespace Cs1_Bibliotek.Grafik
{
    public class UI
    {
        public static void Start(BokService bokService) // Importera bokService: Denna är vår referensobjekt tll repo
        {
            // -------------------------  KOD -----------------------------
            bool isRunning = true;
            while (isRunning) 
            {
                Grafik.UI.HuvudMeny();
                int valSiffra = Grafik.UI.ValSiffra(1, 4);
                switch (valSiffra)
                {
                    case 1:
                        Grafik.UI.Meny1(); // --------------------------------- MENY 1
                        valSiffra = Grafik.UI.ValSiffra(1, 5);
                        switch (valSiffra)
                        {
                            case 1: // Hämta en Bok med id
                                // bokService.HamtaBok();
                                bokService.SokBok();
                                break;

                            case 2: // Visa alla registrerade böcker
                                BokInfoUI(bokService, "Registrerade");
                                break;

                            case 3: // Visa alla tillgängliga böcker
                                BokInfoUI(bokService, "Tillgängliga");
                                break;

                            case 4: // Visa utlånade böcker.
                                BokInfoUI(bokService, "Utlånade");
                                break;

                            case 5: // backa
                                continue;
                        }
                        break;

                    case 2:
                        Grafik.UI.Meny2(); // --------------------------------- MENY 2
                        valSiffra = Grafik.UI.ValSiffra(1, 2);
                        switch (valSiffra)
                        {
                            case 1: // Registrera ny bok
                                bokService.RegistreraBok();
                                break;

                            case 2:

                                continue;
                        }
                        break;

                    case 3:
                        LanaUtIdUI(bokService);
                        break;

                    case 4:
                        isRunning = false;
                        break;
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

                [3] - Låna ut bok

                [4] - Avsluta

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

                [1] - Sök bok

                [2] - Visa alla registrerade böcker

                [3] - Visa tillängliga böcker

                [4] - Visa utlånade bäcker

                [5] - Bakåt

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

                [1] - Registrera ny bok

                [2] - Bakåt

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

        public static void LanaUtIdUI(BokService bokService) // för att kunna lägga in repo som argument.
        {
            Console.Clear();
            Console.WriteLine("LISTA - TILLGÄNGLIGA BÖCKER");
            BokInfoUI(bokService, "Tillgängliga");
            Console.WriteLine("""
                ==============================================
                                LÅNA UT BOK
                """);
            
            // I sysinmatningen's argument, skapar jag en string variabel som skall returneras, så jag kan använda den.
            Sys.SysInmatning.StringKontroll(out string output, 4);
            int BokId = int.Parse(output);

            // nu måste jag låna ut bok bia Bok-ID och sedan uppdatera boklistan.
            foreach (Bok bok in bokService.HamtaBockerILager())
            {
                if(BokId == bok.Id)
                {
                    bok.LanaUt();
                } else
                {
                    Console.WriteLine("Fel inmatning; Bok-ID existerar inte.");
                }
            }

            // Updatera "bokService" repo? = Nej, programmet räknar med ändringar (med argument variabeln) längs programmets gång.

        }
        public static void BokInfoUI(BokService bokService, string valSpecificering)
        {
            
            switch (valSpecificering)
            {
                case "Registrerade": // Visa registrerade böcker
                    foreach (Bok i in bokService.HamtaAllaBocker())
                        Console.WriteLine($"""
                                        |     --- Bok-ID: {i.Id} ---
                                        | Titel           -       {i.Titel}
                                        | Författare      -       {i.Forfattare} 
                                        | Status          -       {i.VisaStatus()}
                                        |__
                                        """);
                    Console.WriteLine("\nKlicka valfri tangent för att fortsätta.");
                    Console.ReadKey();
                    break;

                case "Tillgängliga":

                    foreach (Bok i in bokService.HamtaBockerILager())
                    Console.WriteLine($"""
                                        |     --- Bok-ID: {i.Id} ---
                                        | Titel           -       {i.Titel}
                                        | Författare      -       {i.Forfattare} 
                                        | Status          -       {i.VisaStatus()}
                                        |__
                                        """);
                    Console.WriteLine("\nKlicka valfri tangent för att fortsätta.");
                    Console.ReadKey();
                    break;

                case "Utlånade": 
                    // Vi måste se till i framtiden att det finss en kontroll om detta gäller.
                    foreach (Bok i in bokService.UtLanadeBocker())
                    {
                        Console.WriteLine($"""
                                        |     --- Bok-ID: {i.Id} ---
                                        | Titel           -       {i.Titel}
                                        | Författare      -       {i.Forfattare} 
                                        | Status          -       {i.VisaStatus()}
                                        | Låntagare       -       {i.LanTagare}
                                        |__
                                        """);
                    }

                    Console.WriteLine("\nKlicka valfri tangent för att fortsätta.");
                    Console.ReadKey();
                    break;
            }

        }
    }
}
