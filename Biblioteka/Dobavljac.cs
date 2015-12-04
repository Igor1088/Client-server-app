using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka
{
    [Serializable]
    public class Dobavljac:OpstiDomenskiObjekat
    {
        public override string ToString()
        {
            return naziv;
        }

        int dobavljacID;

        public int DobavljacID
        {
            get { return dobavljacID; }
            set { dobavljacID = value; }
        }
        string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        int pib;

        public int Pib
        {
            get { return pib; }
            set { pib = value; }
        }

        #region OpstiDomenskiObjekat
        public string tabela
        {
            get { return "Dobavljac"; }
        }

        public string kljuc
        {
            get { return "dobavljacID"; }
        }

        public string uslovJedan
        {
            get { return "dobavljacID=" + dobavljacID; }
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
            get { return "naziv='" + naziv + "', pib=" + pib + ""; }
        }

        public string upisivanje
        {
            get { return "(" + dobavljacID + ",'" + naziv + "'," + pib + ")"; }
        }

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Dobavljac d = new Dobavljac();
            d.dobavljacID = Convert.ToInt32(red[0]);
            d.Naziv = red[1].ToString();
            d.Pib = Convert.ToInt32(red[2]);

            return d;
        }
        #endregion


    }
}
