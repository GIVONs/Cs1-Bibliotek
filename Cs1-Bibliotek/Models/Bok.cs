using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Models
{
    public class Bok
    {
        string titel { get; set; }
        string författare { get; set; }
        public bool ärUtlånad { get; private set; } // get (su kan läsa värdet) set (du kan inte komma åt värdet - edit)

        public Bok( string titel, string författare)
        {
            this.titel = titel;
            this.författare = författare;
        }

        public bool LånaUt()
        {
            if (this.ärUtlånad == false)
            {
                Console.WriteLine($"This {this.titel} utlånas.");
                return this.ärUtlånad = true;
            }
            else
            {
                Console.WriteLine($"Boken {this.titel} är redan utlånad");
                return this.ärUtlånad = false;
            }
        }

        public bool LämnaTillbaka()
        {

                if (this.ärUtlånad == false)
                {
                    Console.WriteLine($"Boken {this.titel} hämtas och återlämnas.");
                    
                    return this.ärUtlånad = true;
            }
                else
                {
                    Console.WriteLine($"Boken {this.titel} är i lager, den kan inte hämtas");
                    return this.ärUtlånad = false;

                }
        }

        public string VisaStatus()
        {
            if (this.ärUtlånad == false)
            {
                string meddelande = "I LAGER";
                return meddelande;
            }
            else if (this.ärUtlånad == true)
            {
                string meddelande = "UTLÅNAD";
                return meddelande;
            }
            else { return null; }
        }
    }
}
