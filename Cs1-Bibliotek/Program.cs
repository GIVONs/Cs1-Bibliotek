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

            // -------------------------  KOD -----------------------------
            bool isRunning = true;
            while (isRunning) // för att kunna använda continue i switch-cases
            {
                Grafik.UI.HuvudMeny();
                int valSiffra = Grafik.UI.ValSiffra(1, 3);
                switch (valSiffra)
                {
                    case 1:
                        Grafik.UI.Meny1();
                        valSiffra = Grafik.UI.ValSiffra(1, 3);
                        switch (valSiffra)
                        {
                            case 1:
                                // Hämta med id

                                break;

                            case 2:
                                // Visa alla registrerade böcker

                                break;

                            case 3: // backa
                                continue;
                        }
                        break;

                    case 2:
                        Grafik.UI.Meny2();
                        valSiffra = Grafik.UI.ValSiffra(1, 3);
                        switch (valSiffra)
                        {
                            case 1:
                                // sök i bibliotek via sträng
                                break;

                            case 2:
                                // Registrera ny bok
                                break;

                            case 3: // backa
                                continue;
                        }
                        break;

                    case 3:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
