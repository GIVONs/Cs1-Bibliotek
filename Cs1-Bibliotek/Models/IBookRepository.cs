using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Models
{
    public interface IBookRepository
    { // denna interface ser till att följande instruktioner/kod finns i klassen som ärver interfacet:
        void LaggTill(Bok bok);
        List<Bok> HamtaAlla();
        Bok? HamtaMedId(int idInput);
    }
}
