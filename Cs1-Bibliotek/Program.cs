using Cs1_Bibliotek.DB;
using Cs1_Bibliotek.Models;
//using Cs1_Bibliotek.Services;
using Cs1_Bibliotek.Grafik;
using Cs1_Bibliotek.Services;


namespace Cs1_Bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Startvärden 
            // BokRepository bibliotek = new BokRepository(); 

            IBookRepository repository = new BokRepository(); // Skapar objekt som hanterar böcker
            BokService bokService = new BokService(repository);  // Skicka repository till boktjänsten så att boktjänsten kan använda den.
            // Nu ska du kalla på bokService för att åtgärda boklistan. Du har in

            // Bool som ger om sparad blir = true om boken sparas
/*            bool sparad = bokService.RegistreraBok(
                "Ronja Rövardotter", "Astrid Lindgren");

            Console.WriteLine(sparad ? "Boken Sparades." :
                "Title och författare måste fyllas i.");*/


            UI.Start(bokService);

        }      
    }
}
