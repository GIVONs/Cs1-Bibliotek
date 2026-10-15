using Cs1_Bibliotek.DB;
using Cs1_Bibliotek.Models;
using Cs1_Bibliotek.Grafik;
using Cs1_Bibliotek.Services;


namespace Cs1_Bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Startvärden:
            IBookRepository repository = new BokRepository(); 
            BokService bokService = new BokService(repository); 


            UI.Start(bokService);

        }      
    }
}
