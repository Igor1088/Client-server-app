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
    public partial class Prijava : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public Prijava()
        {
            InitializeComponent();
            if (KontrolerKorisnickogInterfejsa.KontrolerKI.poveziSeNaServer())
            {
                MessageBox.Show("Povezan!");
            }
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kki.prijaviSe(txtUser))
            {
                new PocetnaForma().ShowDialog();               
            }
        }
    }
}
