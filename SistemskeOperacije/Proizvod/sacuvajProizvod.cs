using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemskeOperacije.Proizvod
{
    public class sacuvajProizvod:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.dajSesiju().ubaci(odo);
        }
    }
}
