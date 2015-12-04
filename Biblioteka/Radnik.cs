using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka
{
    [Serializable]
    public class Radnik:OpstiDomenskiObjekat
    {
        public override string ToString()
        {
            return ime;
        }

        int radnikID;

        public int RadnikID
        {
            get { return radnikID; }
            set { radnikID = value; }
        }
        string korisnickoIme;

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }
        string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        string jmbg;

        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        #region OpstiDomenskiObjekat
        public string tabela
        {
            get { return "Radnik"; }
        }

        public string kljuc
        {
            get { return "radnikID"; }
        }

        public string uslovJedan
        {
            get { return "radnikID=" + radnikID; }
        }

        public string uslovDva
        {
            get { return "korisnickoIme='" + korisnickoIme + "'"; }
        }

        public string uslovTri
        {
            get { return null; }
        }

        public string azuriranje
        {
            get { return null; }
        }

        public string upisivanje
        {
            get { return null; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Radnik r = new Radnik();
            r.radnikID = Convert.ToInt32(red[0]);
            r.KorisnickoIme = red[1].ToString();
            r.Ime = red[2].ToString();
            r.Jmbg = red[3].ToString();

            return r;
        }
        #endregion
    }
}
