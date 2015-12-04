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
    public partial class PocetnaForma : Form
    {
        public PocetnaForma()
        {
            InitializeComponent();
        }

        private void unosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosDobavljaca().ShowDialog();
        }

        private void izmenaDobavljacaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IzmenaDobavljaca().ShowDialog();
        }

        private void unosProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosProizvoda().ShowDialog();
        }

        private void izmenaIBrisanjeProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IzmenaIBrisanjeProizvoda().ShowDialog();
        }

        private void unosRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosRacuna().ShowDialog();
        }

        private void storniranjeRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new StornirajRacun().ShowDialog();
        }

        private void izmenaRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IzmenaRacuna().ShowDialog();
        }

        
    }
}
