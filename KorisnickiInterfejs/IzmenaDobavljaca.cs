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
    public partial class IzmenaDobavljaca : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public IzmenaDobavljaca()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void IzmenaDobavljaca_Load(object sender, EventArgs e)
        {
            kki.popuniComboDobavljac(cmbDobavljac);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kki.izmeniDobavljaca(cmbDobavljac, txtNaziv, txtPib)) this.Close();
        }

        private void cmbDobavljac_SelectedIndexChanged(object sender, EventArgs e)
        {
            kki.popuniPolja(cmbDobavljac, txtNaziv, txtPib);
        }
    }
}
