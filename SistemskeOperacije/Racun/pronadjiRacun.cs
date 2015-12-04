using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemskeOperacije.Racun
{
    public class pronadjiRacun : OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Biblioteka.Racun r = Sesija.Broker.dajSesiju().dajZaUslovJedan(odo) as Biblioteka.Racun;
            Biblioteka.StavkaRacuna sr = new Biblioteka.StavkaRacuna();
            sr.RacunID = r.RacunID;
            List<Biblioteka.StavkaRacuna> lista = Sesija.Broker.dajSesiju().dajSveZaUslovDva(sr).OfType<Biblioteka.StavkaRacuna>().ToList<Biblioteka.StavkaRacuna>();
            foreach (Biblioteka.StavkaRacuna stv in lista)
            {
                stv.Proizvod = Sesija.Broker.dajSesiju().dajZaUslovJedan(stv.Proizvod) as Biblioteka.Proizvod;

                r.ListaStavki.Add(stv);
            }

            return r;
        }
    }
}
