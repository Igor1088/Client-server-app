using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Biblioteka
{
    public interface OpstiDomenskiObjekat
    {
        string tabela
        {
            get;
        }

        string kljuc
        {
            get;
        }

        string uslovJedan
        {
            get;
        }

        string uslovDva
        {
            get;
        }

        string uslovTri
        {
            get;
        }

        string azuriranje
        {
            get;
        }

        string upisivanje
        {
            get;
        }
        OpstiDomenskiObjekat napuni(DataRow red);
    }
}
