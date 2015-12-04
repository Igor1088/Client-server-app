using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KontrolerAplikacioneLogike;
using Biblioteka;
using System.Windows.Forms;


namespace KontrolerKorisnickogInterfejsa
{
    public class KontrolerKI
    {
        public static KontrolerAL kal;
        public static Radnik radnik;
        public static Racun racun;

        public static bool poveziSeNaServer()
        {
            kal = new KontrolerAL();
            return kal.poveziSeNaServer();
        }

        public bool prijaviSe(TextBox txtUser)
        {
            Radnik r = new Radnik();
            r.KorisnickoIme = txtUser.Text;

            radnik = kal.prijaviSe(r);

            if (radnik == null)
            {
                MessageBox.Show("Pogresno korisnicko ime!");
                txtUser.Clear();
                txtUser.Focus();
                return false;
            }
            else return true;
        }

        public void kreirajSifru(TextBox txtSifra, GroupBox groupBox1)
        {
            groupBox1.Visible = false;
            Object o = kal.kreirajSifru();

            if (o == null)
            {
                MessageBox.Show("Sistem ne moze da kreira sifru dobavljaca!");
            }
            else
            {
                MessageBox.Show("Sistem je kreirao sifru dobavljaca!");
                txtSifra.Text = o.ToString();
                groupBox1.Visible = true;
            }
        }

        public bool sacuvajDobavljaca(TextBox txtSifra, TextBox txtPib, TextBox txtNaziv)
        {
            Dobavljac d = new Dobavljac();
            d.DobavljacID = Convert.ToInt32(txtSifra.Text);
            d.Naziv = txtNaziv.Text;
            try
            {
                d.Pib = Convert.ToInt32(txtPib.Text);
            }
            catch (Exception)
            {

                Console.WriteLine("Niste ispravno uneli pib!");
                txtPib.Clear();
                txtPib.Focus();
                return false;
            }

            Object o = kal.sacuvajDobavljaca(d);

            if (o == null || (int)o == 0)
            {
                MessageBox.Show("Dobavljac nije sacuvan!");
                return false;
            }
            else
            {
                MessageBox.Show("Dobavljac je uspesno sacuvan!");
                return true;
            }
        }

        public void popuniComboDobavljac(ComboBox cmbDobavljac)
        {
            cmbDobavljac.DataSource = kal.vratiSveDobavljace();
        }

        public bool izmeniDobavljaca(ComboBox cmbDobavljac, TextBox txtNaziv, TextBox txtPib)
        {
            Dobavljac d = cmbDobavljac.SelectedItem as Dobavljac;

            d.Naziv = txtNaziv.Text;
            try
            {
                d.Pib = Convert.ToInt32(txtPib.Text);
            }
            catch (Exception)
            {

                Console.WriteLine("Niste ispravno uneli pib!");
                txtPib.Clear();
                txtPib.Focus();
                return false;
            }

            Object o = kal.izmeniDobavljaca(d);

            if (o == null || (int)o == 0)
            {
                MessageBox.Show("Dobavljac nije izmenjen!");
                return false;
            }
            else
            {
                MessageBox.Show("Dobavljac je uspesno izmenjen!");
                return true;
            }
        }


        public void popuniPolja(ComboBox cmbDobavljac, TextBox txtNaziv, TextBox txtPib)
        {
            Dobavljac d = cmbDobavljac.SelectedItem as Dobavljac;

            txtNaziv.Text = d.Naziv;
            txtPib.Text = d.Pib.ToString();
        }

        public void kreirajSifruProizvoda(TextBox txtSifra, GroupBox groupBox1, ComboBox cmbDob)
        {
            groupBox1.Visible = false;
            Object o = kal.kreirajSifruProizvoda();

            if (o == null)
            {
                MessageBox.Show("Sistem ne moze da kreira sifru proizvoda!");
            }
            else
            {
                MessageBox.Show("Sistem je kreirao sifru proizvoda!");
                txtSifra.Text = o.ToString();
                groupBox1.Visible = true;
                cmbDob.DataSource = kal.vratiSveDobavljace();
            }
        }

        public bool sacuvajProizvod(TextBox txtSifra, TextBox txtOpis, TextBox txtNaziv, TextBox txtKolicina, TextBox txtCena, ComboBox cmbDobavljac)
        {
            Proizvod p = new Proizvod();
            p.ProizvodID = Convert.ToInt32(txtSifra.Text);
            p.Naziv = txtNaziv.Text;
            p.Opis = txtOpis.Text;
            try
            {
                p.Kolicina = Convert.ToInt32(txtKolicina.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Kolicina nije ispravno uneta!");
                txtKolicina.Clear();
                txtKolicina.Focus();
                return false;
            }

            try
            {
                p.Cena = Convert.ToDouble(txtCena.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Cena nije ispravno uneta!");
                txtCena.Clear();
                txtCena.Focus();
                return false;
            }

            p.Dobavljac = cmbDobavljac.SelectedItem as Dobavljac;

            Object o = kal.sacuvajProizvod(p);

            if (o == null || (int)o == 0)
            {
                MessageBox.Show("Proizvod nije sacuvan!");
                return false;
            }
            else
            {
                MessageBox.Show("Proizvod je uspesno sacuvan!");
                return true;
            }

        }


        public void popuniComboProizvod(ComboBox cmbProizvod)
        {
            cmbProizvod.DataSource = kal.vratiSveProizvode();
        }

        public void popuniPolja(ComboBox cmbProizvod, TextBox txtCena, TextBox txtDobavljac, TextBox txtKolicina, TextBox txtNaziv, TextBox txtOpis)
        {
            Proizvod p = cmbProizvod.SelectedItem as Proizvod;
            txtCena.Text = p.Cena.ToString();
            txtDobavljac.Text = p.Dobavljac.ToString();
            txtKolicina.Text = p.Kolicina.ToString();
            txtNaziv.Text = p.Naziv;
            txtOpis.Text = p.Opis;
        }

        public bool izmeniProizvod(ComboBox cmbProizvod, TextBox txtCena, TextBox txtDobavljac, TextBox txtKolicina, TextBox txtNaziv, TextBox txtOpis)
        {
            Proizvod p = cmbProizvod.SelectedItem as Proizvod;


            p.Opis = txtOpis.Text;
            try
            {
                p.Kolicina = Convert.ToInt32(txtKolicina.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Kolicina nije ispravno uneta!");
                txtKolicina.Clear();
                txtKolicina.Focus();
                return false;
            }

            try
            {
                p.Cena = Convert.ToDouble(txtCena.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Cena nije ispravno uneta!");
                txtCena.Clear();
                txtCena.Focus();
                return false;
            }



            Object o = kal.izmeniProizvod(p);

            if (o == null || (int)o == 0)
            {
                MessageBox.Show("Proizvod nije izmenjen!");
                return false;
            }
            else
            {
                MessageBox.Show("Proizvod je uspesno izmenjen!");
                return true;
            }
        }

        public bool obrisiProizvod(ComboBox cmbProizvod)
        {
            Proizvod p = cmbProizvod.SelectedItem as Proizvod;
            Object o = kal.obrisiProizvod(p);

            if (o == null || (int)o == 0)
            {
                MessageBox.Show("Proizvod nije obrisan!");
                return false;
            }
            else
            {
                MessageBox.Show("Proizvod je uspesno obrisan!");
                return true;
            }
        }

        public void kreirajRacun(TextBox txtSifra, ComboBox cmbProizvod, GroupBox groupBox1, DataGridView dgv)
        {
            groupBox1.Visible = false;
            racun = new Racun();
            Object o = kal.kreirajRacun();
            if (o == null)
            {
                MessageBox.Show("Racun ne moze biti kreiran!");
            }
            else
            {
                racun.RacunID = (int)o;
                txtSifra.Text = o.ToString();
                dgv.DataSource = racun.ListaStavki;
                cmbProizvod.DataSource = kal.vratiSveProizvode();
                groupBox1.Visible = true;


            }
        }

        public void dodajStavku(ComboBox cmbProizvod, TextBox txtUkIznos)
        {
            StavkaRacuna sr = new StavkaRacuna();
            sr.RacunID = racun.RacunID;
            sr.RbStavke = racun.ListaStavki.Count + 1;
            sr.Proizvod = cmbProizvod.SelectedItem as Proizvod;
            racun.ListaStavki.Add(sr);
            racun.UkupanIznos += sr.Proizvod.Cena;
            txtUkIznos.Text = racun.UkupanIznos.ToString();
        }

        public bool sacuvajRacun(DateTimePicker dateTimePicker1)
        {
            racun.Datum = dateTimePicker1.Value;
            racun.Radnik = radnik;

            Object o = kal.sacuvajRacun(racun);
            if (o == null || (int)o == 0)
            {
                MessageBox.Show("Racun nije sacuvan!");
                return false;
            }
            else
            {
                MessageBox.Show("Racun je sacuvan!");
                return true;
            }
        }

        public void pronadjiRacun(TextBox txtDatum, TextBox txtSifra, TextBox txtUkIznos, DataGridView dataGridView1, GroupBox groupBox1)
        {
            groupBox1.Visible = false;
            racun = new Racun();
            racun.RacunID = Convert.ToInt32(txtSifra.Text);
            racun = kal.pronadjiRacun2(racun);

            if (racun == null)
            {
                MessageBox.Show("Ne postoji racun sa tim brojem u bazi!");
            }
            else
            {
                txtDatum.Text = racun.Datum.ToShortDateString();
                txtUkIznos.Text = racun.UkupanIznos.ToString();
                dataGridView1.DataSource = racun.ListaStavki;
                groupBox1.Visible = true;
            }
        }

        public void pronadjiRacun2(DateTimePicker dateTimePicker1, TextBox txtSifra, TextBox txtUkIznos, ComboBox cmbProizvod, DataGridView dataGridView1, GroupBox groupBox1)
        {
            groupBox1.Visible = false;
            racun = new Racun();
            racun.RacunID = Convert.ToInt32(txtSifra.Text);
            racun = kal.pronadjiRacun2(racun);

            if (racun == null)
            {
                MessageBox.Show("Ne postoji racun sa tim brojem u bazi!");
            }
            else
            {
                dateTimePicker1.Text = racun.Datum.ToShortDateString();
                txtUkIznos.Text = racun.UkupanIznos.ToString();
                dataGridView1.DataSource = racun.ListaStavki;
                cmbProizvod.DataSource = kal.vratiSveProizvode();
                groupBox1.Visible = true;
            }
        }

        public bool stornirajRacun()
        {

            Object o = kal.stornirajRacun(racun);
            if (o == null || (int)o == 0)
            {
                MessageBox.Show("Racun nije storniran!");
                return false;
            }
            else
            {
                MessageBox.Show("Racun je storniran!");
                return true;
            }
        }

        public void obrisiStavku(DataGridView dataGridView1, TextBox txtUkIznos)
        {
            try
            {
                StavkaRacuna sr = dataGridView1.SelectedRows[0].DataBoundItem as StavkaRacuna;
                racun.UkupanIznos -= sr.Proizvod.Cena;
                txtUkIznos.Text = racun.UkupanIznos.ToString();
                racun.ListaStavki.Remove(sr);
            }
            catch (Exception)
            {

                MessageBox.Show("Niste izabrali stavku za birsanje!");
            }
        }

        public bool izmeniRacun(TextBox txtSifra, DateTimePicker dateTimePicker1, TextBox txtUkIznos, ComboBox cmbProizvod, DataGridView dataGridView1, GroupBox groupBox1)
        {

            racun.RacunID = Convert.ToInt32(txtSifra.Text);
            racun.Datum = Convert.ToDateTime(dateTimePicker1.Text);

            Object o = kal.izmeniRacun(racun);

            if (o == null || (int)o == 0)
            {
                MessageBox.Show("Racun nije izmenjen!");
                return false;
            }
            else
            {
                MessageBox.Show("Racun je uspesno izmenjen!");
                return true;
            }
        }

    }
}
