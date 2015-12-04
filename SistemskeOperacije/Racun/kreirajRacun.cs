using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemskeOperacije.Racun
{
    public class kreirajRacun : OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.dajSesiju().dajSifru(odo);
        }
    }
}
