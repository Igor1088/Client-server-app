using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using Biblioteka;


namespace KontrolerAplikacioneLogike
{
    public class KontrolerAL
    {
        TcpClient klijent;
        BinaryFormatter formater;
        NetworkStream tok;

        public bool poveziSeNaServer()
        {
            try
            {
                klijent = new TcpClient("127.0.0.1", 10000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Radnik prijaviSe(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.prijaviSe;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as Radnik;
        }

        public object kreirajSifru()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.kreirajSifru;
            transfer.TransferObjekat = new Dobavljac();
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object sacuvajDobavljaca(Dobavljac d)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajDobavljaca;
            transfer.TransferObjekat = d;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public List<Dobavljac> vratiSveDobavljace()
        {

            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiDobavljace;
            transfer.TransferObjekat = new Dobavljac();
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (transfer.Rezultat as List<OpstiDomenskiObjekat>).OfType<Dobavljac>().ToList<Dobavljac>();
        }

        public object izmeniDobavljaca(Dobavljac d)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniDobavljaca;
            transfer.TransferObjekat = d;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object kreirajSifruProizvoda()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.kreirajSifruProizvoda;
            transfer.TransferObjekat = new Proizvod();
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object sacuvajProizvod(Proizvod p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajProizvod;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public List<Proizvod> vratiSveProizvode()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiSveProizvode;
            transfer.TransferObjekat = new Proizvod();
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<Proizvod>;
        }

        public object izmeniProizvod(Proizvod p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniProizvod;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object obrisiProizvod(Proizvod p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiProizvod;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object kreirajRacun()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.kreirajRacun;
            transfer.TransferObjekat = new Racun();
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object sacuvajRacun(Racun r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajRacun;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public Racun pronadjiRacun(Racun r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.pronadjiRacun;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as Racun;
        }

        public Racun pronadjiRacun2(Racun r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.pronadjiRacun;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as Racun;
        }

        public object stornirajRacun(Racun r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.stornirajRacun;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object izmeniRacun(Racun racun)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniRacun;
            transfer.TransferObjekat = racun;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }


    }
}
