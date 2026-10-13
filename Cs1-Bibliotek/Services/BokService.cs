using Cs1_Bibliotek.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Cs1_Bibliotek.Sys;

namespace Cs1_Bibliotek.Services
{
    public class BokService
    {
        // Ansvarar för programmets åtgärder: Registrera bok, 


        private readonly IBookRepository _repository;
        public BokService(IBookRepository repository)
        {
            _repository = repository;
        }
        public bool RegistreraBok()
        {
            // Vi ska skapa en bok med: string titel och string författare:
            string titel = "";
            string forfattare = "";
            SysInmatning.StringKontroll(out titel, 1);
            SysInmatning.StringKontroll(out forfattare, 2);

            // här kan vi addera våra inputlogik:
            if (string.IsNullOrWhiteSpace(titel) || string.IsNullOrWhiteSpace(forfattare))
            {
                return false;
            }

            // Här skapas en ny id för boken:
            int nyttId = 1;
            foreach (Bok bok in _repository.HamtaAlla())
            {
                if (bok.Id >= nyttId)
                    nyttId = bok.Id + 1; // Skapar en nytt Id över största siffran i listan.
            }

            Bok nyBok = new Bok(nyttId, titel.Trim(), // Skapar book med nya ID-data & namninmatningen.
                forfattare.Trim());

            _repository.LaggTill(nyBok); // LagTill() finns i "BokRepository", som skapar nya Boken och lägger till den.

            return true;
        }

        public List<Bok> HamtaAllaBocker()
        {
            return _repository.HamtaAlla(); // HamtaAlla() - i "BookRepository".
        }

        public Bok? HamtaBok()
        {
            Console.WriteLine("Vänligen ange bok-ID med 1 siffra (exempel '1', '2', etc.):  ");

            int idInput = Convert.ToInt16(Console.ReadLine());
            return _repository.HamtaMedId(idInput); // returnerar en anropan på HamtaMedId().
        }
    }
}
