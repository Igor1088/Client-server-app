using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka
{
    [Serializable]
    public class Proizvod:OpstiDomenskiObjekat
    {
        public override string ToString()
        {
            return naziv;
        }
        int proizvodID;

        public int ProizvodID
        {
            get { return proizvodID; }
            set { proizvodID = value; }
        }
        string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        double cena;

        public double Cena
        {
            get { return cena; }
            set { cena = value; }
        }
        string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }
        int kolicina;

        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }
        Dobavljac dobavljac;

        public Dobavljac Dobavljac
        {
            get { return dobavljac; }
            set { dobavljac = value; }
        }

        #region OpstiDomenskiObjekat
        public string tabela
        {
            get { return "Proizvod"; }
        }

        public string kljuc
        {
            get { return "proizvodID"; }
        }

        public string uslovJedan
        {
            get { return "proizvodID=" + proizvodID; }
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
            get { return "cena=" + cena + ", kolicina=" + kolicina + ", opis='" + opis + "'"; }
        }

        public string upisivanje
        {
            get { return "(" + proizvodID + ",'" + naziv + "'," + cena + ",'" + opis + "'," + kolicina + "," + Dobavljac.DobavljacID + ")"; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Proizvod p = new Proizvod();
            p.ProizvodID = Convert.ToInt32(red[0]);
            p.Naziv = red[1].ToString();
            p.Cena = Convert.ToDouble(red[2]);
            p.Opis = red[3].ToString();
            p.Kolicina = Convert.ToInt32(red[4]);
            p.Dobavljac = new Dobavljac();
            p.Dobavljac.DobavljacID = Convert.ToInt32(red[5]);
            return p;

        }
        #endregion
    }
}
