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
    public partial class UnosRacuna : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public UnosRacuna()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.kreirajRacun(txtSifra, cmbProizvod, groupBox1, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kki.dodajStavku(cmbProizvod, txtUkIznos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kki.sacuvajRacun(dateTimePicker1)) this.Close();
        }

        
    }
}
