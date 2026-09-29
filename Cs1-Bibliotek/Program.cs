using Cs1_Bibliotek.DB;
using Cs1_Bibliotek.Models;

namespace Cs1_Bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Startvärden 
            Bibliotek bibliotek = new Bibliotek(); // instansiera klassen för att använda den här (som ett egen objekt).



            // -------------------------  KOD -----------------------------

            // nu ska jag göra ett meny (skippa måndag gå till tisdag pdf del 2) med:
            // val att låna ut -> programmen ska då låta oss låna bok som vi söker via id, statusen ändras till arUtlanad = true (kontrollera inmatningen)

            // Låta oss se vilka böcker är utlånade vs fins i lager

            // Ta tillbaka en bok (kanske denna kan vara en meny som först går genom de utlånade böckerna och ger os val av en åtgärd för en).

            // SISTA - Låta oss lägga till en bok

            Console.ReadKey();
        }
    }
}
