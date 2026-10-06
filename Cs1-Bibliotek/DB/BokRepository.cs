using Cs1_Bibliotek.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;

namespace Cs1_Bibliotek.DB
{
    // Denna klass ansvarar för; representerar vår databas, lägger till (set) och hämtar böcker (get).
    public class BokRepository : IBookRepository
    {
        private readonly List<Bok> _bocker = new();


        // Metoder som angår listan i helhet - åtgärder med den:
        public List<Bok> ReferensLista() // Skapar en kopia av vår boklista. Längre ner gör du en kopia bara för att
                                         //  hindra ändringsmetoder i program.cs att ändra _bocker. (allt som läggs till är permanent i originella)
        {
            return new List<Bok>(_bocker);
        }

        public List<Bok> HamtaTillgangligaBacker()
        {
            foreach (Bok i in _bocker)
            {
                if (i.arUtlånad == false)
                {
                    Console.WriteLine($"Bok - BokID {i.Id}: '{i.titel}' av {i.forfattare}.");
                    return new List<Bok>(_bocker); // I andra ändan anger du variabeln för nya List-kopian
                    // Säkerheten här är att du kommer senad använda nya kopian för att ändra saker
                }  
            }
            return null;
        }

        // interface implementation -----------------
        public void LaggTill(Bok bok)
        {
            _bocker.Add(bok); // Denna läggs till i den originella privata listan
        }

        public List<Bok> HamtaAlla() // Skapar kopia av listan (säkring för att inte ändra den originella)
        {
            return new List<Bok>(_bocker);
        }

        public Bok? HamtaMedId(int id)
        {
            Console.WriteLine("Vänligen ange bok-ID med 1 siffra (exempel '1', '2', etc.): ");

            id = Convert.ToInt16(Console.ReadLine());
            foreach (Bok i in _bocker)
            {
                if (i.Id == id)
                {
                    Console.WriteLine($"Hittat - BokID {i.Id}: '{i.titel}' av {i.forfattare}.");
                    Console.ReadKey();
                    return i;
                }
            }
            Console.WriteLine("Misslyckades: Boken finns inte eller fel angivet ID.");
            return null;
        }
    }

}
