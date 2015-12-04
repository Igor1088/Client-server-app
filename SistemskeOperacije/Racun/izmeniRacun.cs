using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemskeOperacije.Racun
{
    public class izmeniRacun : OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Biblioteka.Racun r = odo as Biblioteka.Racun;
            if (Sesija.Broker.dajSesiju().azuriraj(r) != 0)
            {
                Sesija.Broker.dajSesiju().obrisi(r.ListaStavki[0]);
                foreach (Biblioteka.StavkaRacuna sr in r.ListaStavki)
                {

                    sr.RacunID = r.RacunID;
                    Sesija.Broker.dajSesiju().ubaci(sr);
                }
            }
            return 1;
        }
    }
}
