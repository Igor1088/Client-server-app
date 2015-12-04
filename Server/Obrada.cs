using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Biblioteka;
using Sesija;
using System.Threading;

namespace Server
{
    
    using SistemskeOperacije.Radnik;
    using SistemskeOperacije.Dobavljac;
    using SistemskeOperacije.Proizvod;
    using SistemskeOperacije.Racun;
    

    public class Obrada
    {
        BinaryFormatter formater;
        NetworkStream tok;

        public Obrada(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart ts = obradiKlijenta;
            Thread nit = new Thread(ts);
            nit.Start();
        }

        public void obradiKlijenta()
        {
            int operacija = 0;
            while (operacija != (int)Operacije.Kraj)
            {
                TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                switch (transfer.Operacija)
                {
                    case Operacije.prijaviSe:
                        prijavaRadnika pr = new prijavaRadnika();
                        transfer.Rezultat = pr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.kreirajSifru:
                        kreirajSifruDobavljaca ksd = new kreirajSifruDobavljaca();
                        transfer.Rezultat = ksd.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.sacuvajDobavljaca:
                        sacuvajDobavljaca sd = new sacuvajDobavljaca();
                        transfer.Rezultat = sd.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.vratiDobavljace:
                        vratiSveDobavljace vsd = new vratiSveDobavljace();
                        transfer.Rezultat = vsd.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.izmeniDobavljaca:
                        izmeniDobavljaca id = new izmeniDobavljaca();
                        transfer.Rezultat = id.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.kreirajSifruProizvoda:
                        kreirajSifruProizvoda ksp = new kreirajSifruProizvoda();
                        transfer.Rezultat = ksp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.sacuvajProizvod:
                        sacuvajProizvod sp = new sacuvajProizvod();
                        transfer.Rezultat = sp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.vratiSveProizvode:
                        vratiSveProizvode vsp = new vratiSveProizvode();
                        transfer.Rezultat = vsp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.izmeniProizvod:
                        izmeniProizvod ip = new izmeniProizvod();
                        transfer.Rezultat = ip.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.obrisiProizvod:
                        obrisiProizvod op = new obrisiProizvod();
                        transfer.Rezultat = op.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.kreirajRacun:
                        kreirajRacun kr = new kreirajRacun();
                        transfer.Rezultat = kr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.sacuvajRacun:
                        sacuvajRacun sr = new sacuvajRacun();
                        transfer.Rezultat = sr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.pronadjiRacun:
                        pronadjiRacun prr = new pronadjiRacun();
                        transfer.Rezultat = prr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.pronadjiRacun2:
                        pronadjiRacun prr2 = new pronadjiRacun();
                        transfer.Rezultat = prr2.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.stornirajRacun:
                        stornirajRacun src = new stornirajRacun();
                        transfer.Rezultat = src.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.izmeniRacun:
                        izmeniRacun ir = new izmeniRacun();
                        transfer.Rezultat = ir.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                        formater.Serialize(tok, transfer);
                        break;

                    case Operacije.Kraj: operacija = 1;
                        break;
                    default:
                        break;
                }

            }

        }
    }
}
