using Cs1_Bibliotek.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Cs1_Bibliotek.Sys;
using Cs1_Bibliotek.DB;

namespace Cs1_Bibliotek.Services
{
    public class BokService
    {
        // Ansvarar för programmets åtgärder: Registrera bok, 


        private readonly IBookRepository _repository; // Detta kommer göra att vi kan bara kalla på lika metoder för "_repository"'s interface
        public BokService(IBookRepository repository)
        {
            _repository = repository;
        }
        public bool RegistreraBok()
        {
            bool running = true;
            while (running)
            {// Vi ska skapa en bok med: string titel och string författare:
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

                Console.WriteLine("Vill du registrera en till bok - J/N?: ");
                string val = Console.ReadLine().Trim().ToUpper();
                if (val == "N")
                {
                    running = false;
                }

            }
            return true;

        }

        public List<Bok> UtLanadeBocker()
            // När jag skapar denna verkar Interface bara referera till saker som ligger i interface för "BokRepository" alla andra är privata funktioner.
            // Så interface är också ett sätt att bestämma tillgängliga metoder för en klass som ärver och implementerar denna.
        {
            return _repository.HamtaUtlanadeBocker();
        } 
        public List<Bok> HamtaAllaBocker()
        {
            return _repository.HamtaAlla();
        }

        public Bok? HamtaBok()
        {
            Console.WriteLine("Vänligen ange bok-ID med 1 siffra (exempel '1', '2', etc.):  ");

            int idInput = Convert.ToInt16(Console.ReadLine());
            return _repository.HamtaMedId(idInput); // returnerar en anropan på HamtaMedId().
        }

        public List<Bok> HamtaBockerILager()
        {
            return _repository.HamtaTillgangliga();
        }

        public Bok? SokBok()
        {
            Console.Clear();
            Console.WriteLine("Sök boken - Titel/Författare");
            return _repository.SokBok();
        }
    }
}
