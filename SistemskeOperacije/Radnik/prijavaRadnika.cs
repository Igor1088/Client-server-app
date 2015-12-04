using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemskeOperacije.Radnik
{
    public class prijavaRadnika : OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.dajSesiju().dajZaUslovDva(odo);
        }
    }
}
