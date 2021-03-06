﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KorisnickiInterfejs
{
    public partial class UnosProizvoda : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public UnosProizvoda()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.kreirajSifruProizvoda(txtSifra, groupBox1, cmbDobavljac);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kki.sacuvajProizvod(txtSifra, txtOpis, txtNaziv, txtKolicina, txtCena, cmbDobavljac)) this.Close();
        }
    }
}
