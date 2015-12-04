using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SistemskeOperacije.Proizvod
{
    public class vratiSveProizvode:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            List<Biblioteka.Proizvod> lista = Sesija.Broker.dajSesiju().dajSve(odo).OfType<Biblioteka.Proizvod>().ToList<Biblioteka.Proizvod>();
            foreach (Biblioteka.Proizvod p in lista)
            {
                p.Dobavljac = Sesija.Broker.dajSesiju().dajZaUslovJedan(p.Dobavljac) as Biblioteka.Dobavljac;
            }

            return lista;
        }
    }
}
