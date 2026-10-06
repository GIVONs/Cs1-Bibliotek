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
        // Jag antar att denna klass, instansieras med en lista. Hur får jag böcker in i listan?.
        private List<Bok> bocker = new List<Bok>();

        public BokRepository() 
        {
            // kontruktorn intitierar med dessa bok-värden i instansiering till objekt.
            Bok bok1 = new Bok(1, "Harry Potter", "J.K Rowling");
            Bok bok2 = new Bok(2, "Ice and Fire", "George R.R. Martin");
            Bok bok3 = new Bok(3, "Cooking With Mushrooms", "Mario & Luigi");
            Bok bok4 = new Bok(4, "The Illiad", "Homer");

            // Lägger in böckerna i listan - (om flera klasser instansieras kommer vi ha dubbla böcker)
            bocker.Add(bok1);
            bocker.Add(bok2);
            bocker.Add(bok3);
            bocker.Add(bok4);
        }

        // Metoder som angår listan i helhet - åtgärder med den:

        public List<Bok> ReferensLista() // Skapar en kopia av vår boklista.
        {
            return new List<Bok>(bocker);
        }

        public Bok? HämtaBok(int id)
        {
            Console.WriteLine("Vänligen ange bok-ID med 1 siffra (exempel '1', '2', etc.): ");

            id = Convert.ToInt16(Console.ReadLine());
            foreach (Bok i in bocker)
            {
                if (i.Id == id)
                {
                    Console.WriteLine($"Hittat - BokID {i.Id}: '{i.titel}' av {i.forfattare}.");
                    return i;
                }
            }
            Console.WriteLine("Misslyckades: Boken finns inte eller fel angivet ID.");
            return null;
        }

        public List<Bok> HamtaBacker() // "Shallow Copy"
        {
            return new List<Bok>(bocker); 
        }

        public List<Bok> HamtaTillgangligaBacker()
        {
            foreach (Bok i in bocker)
            {
                if (i.arUtlånad == false)
                {
                    Console.WriteLine($"Bok - BokID {i.Id}: '{i.titel}' av {i.forfattare}.");
                    return new List<Bok>(bocker);
                }  
            }
            return null;
        }

        // interface implementation -----------------
        public void LaggTill(Bok bok)
        {
            throw new NotImplementedException();
        }

        public List<Bok> HamtaAlla()
        {
            throw new NotImplementedException();
        }

        public Bok? HamtaMedId(int id)
        {
            throw new NotImplementedException();
        }
    }

}
