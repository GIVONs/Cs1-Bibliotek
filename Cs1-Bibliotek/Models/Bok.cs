using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Models
{
    public class Bok
    {
        public int Id { get; private set; } // public för att göra variabel åtkomlig. get; (du kan läsa värdet). set; (du kan inte komma åt värdet, a.k.a. redigera den om "private")
        public string Titel { get; set; }
        public string Forfattare { get; set; }
        public bool ArUtlånad { get; private set; } 

        // för att sätta en regel för pris
        private decimal _pris { get; set; } // gömma värdet och använda den i "Pris"
        public decimal Pris                 //  för att sätta regler för inmatning/output.
        {
            get {
                return _pris; // returnerar bara det som är "setted".
            }
            private set
            {
                decimal MaxPris = 1000m;
                if (value < 0 || value > MaxPris)
                    throw new ArgumentOutOfRangeException(nameof(value));
                else _pris = value;
            }
        }


        public Bok( int Id, string titel, string författare) // ------------------------------------------ Konstruktor
        {
            this.Id = Id;
            this.Titel = titel;
            this.Forfattare = författare;
        }

        // Metoder som angår bokens (denna klass) egna stat.
        public bool LanaUt()   
        {
            if (this.ArUtlånad == false)
            {
                Console.WriteLine($"This {this.Titel} utlånas.");
                return this.ArUtlånad = true;
            }
            else
            {
                Console.WriteLine($"Boken {this.Titel} är redan utlånad");
                return this.ArUtlånad = false;
            }
        }

        public bool LamnaTillbaka()
        {

                if (this.ArUtlånad == false)
                {
                    Console.WriteLine($"Boken {this.Titel} hämtas och återlämnas.");
                    
                    return this.ArUtlånad = true;
            }
                else
                {
                    Console.WriteLine($"Boken {this.Titel} är i lager, den kan inte hämtas");
                    return this.ArUtlånad = false;

                }
        }

        public string VisaStatus()
        {
            if (this.ArUtlånad == false)
            {
                string meddelande = "I LAGER";
                return meddelande;
            }
            else if (this.ArUtlånad == true)
            {
                string meddelande = "UTLÅNAD";
                return meddelande;
            }
            else { return null; }
        }

    }
}