using Cs1_Bibliotek.Models;

namespace Cs1_Bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Bok bok1 = new Bok("Harry Potter", "J.K Rowling");
            Bok bok2 = new Bok("Ice and Fire", "George R.R. Martin");

            string status1 = bok1.VisaStatus();
            string status2 = bok2.VisaStatus();

            Console.WriteLine($"""

                Böcker i databasen.
                - Book 1:           -   Status: {status1}
                - Book 2:           -   Status: {status2}
                
                """);

            // --------------------------- STEG 2 --------------------

            Console.WriteLine("Klicka på valfri tangent för att låna ut bok 1.");
            Console.ReadLine();

            bok1.LånaUt();
            status1 = bok1.VisaStatus();
            status2 = bok2.VisaStatus();

            Console.WriteLine($"""

                Böcker i databasen.
                - Book 1:           -   Status: {status1}
                - Book 2:           -   Status: {status2}
                
                """);

        }
    }
}
