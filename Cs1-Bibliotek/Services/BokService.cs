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
        public bool RegistreraBok(string titel, string forfattare)
        {
            // Denna ansvarar för att ange data, och anropa på skapa bok i "BokRepository".
            Sys.SysInmatning.StringKontroll(titel);
            Sys.SysInmatning.StringKontroll(forfattare);

            int nyttId = 1;
            foreach (Bok bok in _repository.HamtaAlla())
            {
                if (bok.Id >= nyttId)
                    nyttId = bok.Id + 1; // Skapar en nytt Id som största siffran.
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

        public Bok? HamtaBok(int idInput)
        {
            return _repository.HamtaMedId(idInput); // returnerar en anropan på HamtaMedId().
        }
    }
}
