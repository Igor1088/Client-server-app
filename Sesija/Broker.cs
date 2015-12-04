using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Sesija
{
    public class Broker
    {
        OleDbConnection konekcija;
        OleDbTransaction transakcija;


        public static Broker instanca;

        public static Broker dajSesiju()
        {
            if (instanca == null)
            {
                instanca = new Broker();
            }
            return instanca;
        }

        public void otvoriKonekciju()
        {
            try
            {
                konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Igor\Documents\Visual Studio 2010\Projects\Projektni\Baza.accdb");
                konekcija.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspesna konekcija!");
                
            }
        }

        public void zatvoriKonekciju()
        {
            try
            {

                konekcija.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Nije moguce zatvoriti konekciju!");
            }
        }
        public void zapocniTransakciju()
        {
            try
            {
                transakcija = konekcija.BeginTransaction();
            }
            catch (Exception)
            {

                MessageBox.Show("Neuspesna transakcija!");
            }
        }

        public void ponistiTransakciju()
        {
            try
            {
                transakcija.Rollback();
            }
            catch (Exception)
            {

                MessageBox.Show("Neuspesno ponistavanje!");
            }
        }

        public void potvrdiTransakciju()
        {
            try
            {
                transakcija.Commit();
            }
            catch (Exception)
            {

                MessageBox.Show("Neuspesna potvrda transakcije!");
            }
        }

        public List<OpstiDomenskiObjekat> dajSve(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT * FROM " + odo.tabela;
            OleDbDataReader citac = null;
            OleDbCommand komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
                foreach (DataRow red in tabela.Rows)
                {
                    OpstiDomenskiObjekat pom = odo.napuni(red);
                    lista.Add(pom);
                }
                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
            finally
            {
                if (citac != null)
                {
                    citac.Close();
                }
            }
        }

        public List<OpstiDomenskiObjekat> dajSveZaUslovDva(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT * FROM " + odo.tabela + " WHERE " + odo.uslovDva;
            OleDbDataReader citac = null;
            OleDbCommand komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
                foreach (DataRow red in tabela.Rows)
                {
                    OpstiDomenskiObjekat pom = odo.napuni(red);
                    lista.Add(pom);
                }
                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
            finally
            {
                if (citac != null)
                {
                    citac.Close();
                }
            }
        }

        public List<OpstiDomenskiObjekat> dajSveZaUslovTri(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT * FROM " + odo.tabela + " WHERE " + odo.uslovTri;
            OleDbDataReader citac = null;
            OleDbCommand komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
                foreach (DataRow red in tabela.Rows)
                {
                    OpstiDomenskiObjekat pom = odo.napuni(red);
                    lista.Add(pom);
                }
                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
            finally
            {
                if (citac != null)
                {
                    citac.Close();
                }
            }
        }

        public OpstiDomenskiObjekat dajZaUslovJedan(OpstiDomenskiObjekat odo)
        {
            string upitniString = "SELECT * FROM " + odo.tabela + " WHERE " + odo.uslovJedan;
            OleDbDataReader reader = null;
            OleDbCommand komanda = new OleDbCommand(upitniString, konekcija, transakcija);
            try
            {
                reader = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(reader);
                DataRow red;
                if (tabela.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    red = tabela.Rows[0];
                }
                return odo.napuni(red);
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public OpstiDomenskiObjekat dajZaUslovDva(OpstiDomenskiObjekat odo)
        {
            string upitniString = "SELECT *FROM " + odo.tabela + " WHERE " + odo.uslovDva;
            ;
            OleDbDataReader reader = null;
            OleDbCommand komanda = new OleDbCommand(upitniString, konekcija, transakcija);
            try
            {
                reader = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(reader);
                DataRow red;
                if (tabela.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    red = tabela.Rows[0];
                }
                return odo.napuni(red);
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public int azuriraj(OpstiDomenskiObjekat odo)
        {
            string upit = "UPDATE " + odo.tabela + " SET " + odo.azuriranje + " WHERE " + odo.uslovJedan;
            OleDbCommand komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
        }

        public int ubaci(OpstiDomenskiObjekat odo)
        {
            string upit = "INSERT INTO " + odo.tabela + " VALUES " + odo.upisivanje;
            OleDbCommand komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
        }

        public int obrisi(OpstiDomenskiObjekat odo)
        {
            string upit = "DELETE * FROM " + odo.tabela + " WHERE " + odo.uslovJedan;
            OleDbCommand komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
        }

        public int obrisiSveZaUslov(OpstiDomenskiObjekat odo)
        {
            string upit = "DELETE * FROM " + odo.tabela + " WHERE " + odo.uslovDva;
            OleDbCommand komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Greska u radu sa bazom!");
            }
        }

        public int dajSifru(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT MAX(" + odo.kljuc + ") FROM " + odo.tabela;
            OleDbCommand komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }





    }
}
