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
    public partial class IzmenaRacuna : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public IzmenaRacuna()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.pronadjiRacun2(dateTimePicker1, txtSifra, txtUkIznos, cmbProizvod, dataGridView1, groupBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kki.dodajStavku(cmbProizvod, txtUkIznos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kki.obrisiStavku(dataGridView1, txtUkIznos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kki.izmeniRacun(txtSifra, dateTimePicker1, txtUkIznos, cmbProizvod, dataGridView1, groupBox1)) this.Close();
        }
    }
}
