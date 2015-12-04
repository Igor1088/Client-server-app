using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemskeOperacije.Racun
{
    public class sacuvajRacun : OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Biblioteka.Racun r = odo as Biblioteka.Racun;
            if (Sesija.Broker.dajSesiju().ubaci(r) != 0)
            {
                foreach (Biblioteka.StavkaRacuna sr in r.ListaStavki)
                {

                    Sesija.Broker.dajSesiju().ubaci(sr);
                }
            }

            return 1;
        }
    }
}
