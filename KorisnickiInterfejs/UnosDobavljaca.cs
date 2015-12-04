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
    public partial class UnosDobavljaca : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public UnosDobavljaca()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.kreirajSifru(txtSifra, groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kki.sacuvajDobavljaca(txtSifra, txtPib, txtNaziv))
            {
                this.Close();
            }
        }
    }
}
