using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KorisnickiInterfejs
{
    public partial class IzmenaIBrisanjeProizvoda : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public IzmenaIBrisanjeProizvoda()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void IzmenaIBrisanjeProizvoda_Load(object sender, EventArgs e)
        {
            kki.popuniComboProizvod(cmbProizvod);
        }

        private void cmbProizvod_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            kki.popuniPolja(cmbProizvod, txtCena, txtDobavljac, txtKolicina, txtNaziv, txtOpis);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kki.izmeniProizvod(cmbProizvod, txtCena, txtDobavljac, txtKolicina, txtNaziv, txtOpis)) this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kki.obrisiProizvod(cmbProizvod)) this.Close();
        }
    }
}
