using Cs1_Bibliotek.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using Cs1_Bibliotek.Sys;

namespace Cs1_Bibliotek.DB
{
    // Denna klass ansvarar för; representerar vår databas, lägger till (set) och hämtar böcker (get).
    public class BokRepository : IBookRepository
    {
        private readonly List<Bok> _bocker = new();

        public List<Bok> ReferensLista()
        {
            return new List<Bok>(_bocker); // Skapar en kopia: saker kan lägga till och ändras från denne utan att röra interna repo.
        }

        public List<Bok> HamtaUtlanadeBocker() // why doesn't Interface detect this? (only when i create things here) (A)
        {
            foreach (Bok i in _bocker)
            {
                if (i.ArUtLånad == true)
                {
                    return new List<Bok>(_bocker);
                }
            }
            return null;
        }

        // --------------- Intreface Implementations -------------------
        // INFO-samling:
        // - Interfacet bestämmer också vilka metoder som är tillgängliga/publika i den klassen som ärver
        //      och implementerar den, t.ex när klassen blir/skapar en objekt med interface inkluderat, kan bara interface metoder nås.
        public List<Bok> HamtaAlla() // Skapar kopia av listan (säkring för att inte ändra den originella)
        {
            return new List<Bok>(_bocker);
        }

        public List<Bok> HamtaTillgangliga()
        {
            foreach (Bok i in _bocker)
            {
                if (i.ArUtLånad == false)
                {
                    // Varenda bok som är inte utlånad går in i en lista:
                    return new List<Bok>(_bocker);
                }
            }
            return null;
        }

        
        public void LaggTill(Bok bok)
        {
            _bocker.Add(bok); // Denna läggs till i den originella privata listan
        }


        public Bok? HamtaMedId(int idInput)
        {
            foreach (Bok i in _bocker) // från internal repo (komm ihåg att du har egenskapen att addera till den i LagTill)
            {
                if (i.Id == idInput)
                {
                    Console.WriteLine($"Hittat - BokID {i.Id}: '{i.Titel}' av {i.Forfattare}.");
                    Console.ReadKey();
                    return i;
                }
            }
            Console.WriteLine("Misslyckades: Boken finns inte eller fel angivet ID.");
            return null;
        }

        public Bok? SokBok()
        { 
            string sokText = Console.ReadLine();
            foreach(Bok i in _bocker)
            {
                if (i.Titel.Contains(sokText, StringComparison.OrdinalIgnoreCase) || i.Forfattare.Contains(sokText, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Hittat - BokID {i.Id}: '{i.Titel}' av {i.Forfattare}.");
                    Console.ReadKey();
                    return i;
                }
            }
            Console.WriteLine("Misslyckades: Boken finns inte eller fel angivet text.");
            return null;
        }

    }
}
