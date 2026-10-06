using Cs1_Bibliotek.DB;
using Cs1_Bibliotek.Models;

namespace Cs1_Bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Startvärden 
            BokRepository bibliotek = new BokRepository(); // instansiera klassen för att använda den här (som ett egen objekt).

            // -------------------------  KOD -----------------------------

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

                            break;

                        case 2:

                            break;

                        case 3:

                            break;
                    }
                    break;

                case 2:
                    Grafik.UI.Meny2();
                    valSiffra = Grafik.UI.ValSiffra(1, 3);
                    switch (valSiffra)
                    {
                        case 1:

                            break;

                        case 2:

                            break;

                        case 3:

                            break;
                    }
                    break;

                case 3:

                    break;
            }
        }
    }
}
