using System;
using System.Collections.Generic;
using System.Text;
using Cs1_Bibliotek.Sys;

namespace Cs1_Bibliotek.Models
{
    public class Bok
    {
        public int Id { get; private set; } // public för att göra variabel åtkomlig. get; (du kan läsa värdet). set; (du kan inte komma åt värdet, a.k.a. redigera den om "private")
        public string Titel { get; set; }
        public string Forfattare { get; set; }
        public bool ArUtLånad { get; private set; }
        public string? LanTagare { get; private set; }

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
            if (this.ArUtLånad == false)
            {
                Console.WriteLine($"This {this.Titel} utlånas.");

                Sys.SysInmatning.StringKontroll(out string namn, 3);
                LanTagare = namn;

                return this.ArUtLånad = true;
            }
            else
            {
                Console.WriteLine($"Boken {this.Titel} är redan utlånad");
                return this.ArUtLånad = false;
            }
        }

        public bool LamnaTillbaka()
        {
            if (this.ArUtLånad == false)
            {

                Console.WriteLine($"Boken {this.Titel} hämtas och återlämnas.");
                LanTagare = null;
                    
                return this.ArUtLånad = true;
            } else
            {
                Console.WriteLine($"Boken {this.Titel} är i lager, den kan inte hämtas");
                return this.ArUtLånad = false;
            }
        }

        public string VisaStatus()
        {
            if (this.ArUtLånad == false)
            {
                string meddelande = "I LAGER";
                return meddelande;
            }
            else if (this.ArUtLånad == true)
            {
                string meddelande = "UTLÅNAD";
                return meddelande;
            }
            else { return null; }
        }

    }
}