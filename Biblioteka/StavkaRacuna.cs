using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Biblioteka
{
    [Serializable]
    public class StavkaRacuna:OpstiDomenskiObjekat
    {
        int racunID;
        [Browsable(false)]
        public int RacunID
        {
            get { return racunID; }
            set { racunID = value; }
        }
        int rbStavke;

        public int RbStavke
        {
            get { return rbStavke; }
            set { rbStavke = value; }
        }
        Proizvod proizvod;

        public Proizvod Proizvod
        {
            get { return proizvod; }
            set { proizvod = value; }
        }

        #region OpstiDomenskiObjekat
        [Browsable(false)]
        public string tabela
        {
            get { return "StavkaRacuna"; }
        }
        [Browsable(false)]
        public string kljuc
        {
            get { return null; }
        }
        [Browsable(false)]
        public string uslovJedan
        {
            get { return "racunID=" + racunID; }
        }
        [Browsable(false)]
        public string uslovDva
        {
            get { return "racunID=" + racunID; }
        }
        [Browsable(false)]
        public string uslovTri
        {
            get { return null; }
        }
        [Browsable(false)]
        public string azuriranje
        {
            get { return null; }
        }
        [Browsable(false)]
        public string upisivanje
        {
            get { return "(" + racunID + "," + rbStavke + "," + proizvod.ProizvodID + ")"; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            StavkaRacuna sr = new StavkaRacuna();
            sr.racunID = Convert.ToInt32(red[0]);
            sr.rbStavke = Convert.ToInt32(red[1]);
            sr.Proizvod = new Proizvod();
            sr.Proizvod.ProizvodID = Convert.ToInt32(red[2]);

            return sr;
        }
        #endregion
    }
}
