using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Biblioteka
{
    [Serializable]
    public class Racun:OpstiDomenskiObjekat
    {
        int racunID;

        public int RacunID
        {
            get { return racunID; }
            set { racunID = value; }
        }
        double ukupanIznos;

        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set { ukupanIznos = value; }
        }
        DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        Radnik radnik;

        public Radnik Radnik
        {
            get { return radnik; }
            set { radnik = value; }
        }

        BindingList<StavkaRacuna> listaStavki;

        public BindingList<StavkaRacuna> ListaStavki
        {
            get { return listaStavki; }
            set { listaStavki = value; }
        }

        public Racun()
        {
            listaStavki = new BindingList<StavkaRacuna>();
        }

        #region OpstiDomenskiObjekat
        public string tabela
        {
            get { return "Racun"; }
        }

        public string kljuc
        {
            get { return "racunID"; }
        }

        public string uslovJedan
        {
            get { return "racunID=" + racunID; }
        }

        public string uslovDva
        {
            get { return null; }
        }

        public string uslovTri
        {
            get { return null; }
        }

        public string azuriranje
        {
            get { return "ukupanIznos='" + ukupanIznos + "', datum='" + datum.ToShortDateString() + "'"; }
        }

        public string upisivanje
        {
            get { return "(" + racunID + ",'" + datum.ToShortDateString() + "'," + ukupanIznos + "," + radnik.RadnikID + ")"; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Racun r = new Racun();
            r.RacunID = Convert.ToInt32(red[0]);
            r.Datum = Convert.ToDateTime(red[1]);
            r.ukupanIznos = Convert.ToDouble(red[2]);
            r.Radnik = new Radnik();
            r.Radnik.RadnikID = Convert.ToInt32(red[3]);

            return r;
        }
        #endregion
    }
}
