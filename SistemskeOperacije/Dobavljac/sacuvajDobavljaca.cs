using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemskeOperacije.Dobavljac
{
    public class sacuvajDobavljaca:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {

            return Sesija.Broker.dajSesiju().ubaci(odo);
        }
    }
}
