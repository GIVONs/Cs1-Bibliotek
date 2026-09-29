using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Models
{
    public class Bok
    {
        public int Id { get; private set; } // public för att göra variabel åtkomlig. get; (du kan läsa värdet). set; (du kan inte komma åt värdet, a.k.a. redigera den om "private")
        public string titel { get; set; }
        public string forfattare { get; set; }
        public bool arUtlånad { get; private set; } 

        public Bok( int Id, string titel, string författare) // ------------------------------------------ Konstruktor
        {
            this.Id = Id;
            this.titel = titel;
            this.forfattare = författare;
        }

        public bool LanaUt()   
        {
            if (this.arUtlånad == false)
            {
                Console.WriteLine($"This {this.titel} utlånas.");
                return this.arUtlånad = true;
            }
            else
            {
                Console.WriteLine($"Boken {this.titel} är redan utlånad");
                return this.arUtlånad = false;
            }
        }

        public bool LamnaTillbaka()
        {

                if (this.arUtlånad == false)
                {
                    Console.WriteLine($"Boken {this.titel} hämtas och återlämnas.");
                    
                    return this.arUtlånad = true;
            }
                else
                {
                    Console.WriteLine($"Boken {this.titel} är i lager, den kan inte hämtas");
                    return this.arUtlånad = false;

                }
        }

        public string VisaStatus()
        {
            if (this.arUtlånad == false)
            {
                string meddelande = "I LAGER";
                return meddelande;
            }
            else if (this.arUtlånad == true)
            {
                string meddelande = "UTLÅNAD";
                return meddelande;
            }
            else { return null; }
        }

    }
}