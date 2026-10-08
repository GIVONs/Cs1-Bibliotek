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

            IBookRepository repository = new BokRepository(); // creating a BookRepo but the type is a Interfce
            BokService service = new BokService(repository);

            bool sparad = service.RegistreraBok(
                "Ronja Rövardotter", "Astrid Lindgren");

            Console.WriteLine(sparad ? "Boken Sparades." :
                "Title och författare måste fyllas i.");

/*            foreach (Bok bok in service.HamtaAllaBocker())
            {
                Console.WriteLine($"{bok.Id}: {bok.Titel}");
            }*/

            UI.Start();

        }      
    }
}
