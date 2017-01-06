using EvidencijaRacunaObrta.Business.Response;
using EvidencijaRacunaObrta.Models.ObrtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Business
{
    public class InicijalnoPunjenje : ResponseBase
    {
        EvidencijaContext db;
        int userId;
        public InicijalnoPunjenje(EvidencijaContext db, int userId)
        {
            this.db = db;
            this.userId = userId;
        }

        public ResponseBase Napuni()
        {
            ResponseBase response = new ResponseBase();
            response.Success = true;
            try
            {
                Obrt obrt = CreateObrtDetalj(userId);
                db.Obrti.Add(obrt);
                List<Klijent> k = Klijenti(userId);
                db.Klijenti.AddRange(k);
                FooterTemplate footer = RacunFooter(userId);
                db.FooteriRacuna.Add(footer);
                Racun r = JedanRacun(userId, footer, obrt.ZiroRacun, k[0]);
                db.Racuni.Add(r);
                Stavka s = JednaStavka(userId, r.Id);
                db.Stavke.Add(s);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message.ToLower().Contains("inner exc") ? ex.InnerException.Message : ex.Message;
            }

            return response;
        }
        public Obrt CreateObrtDetalj(int userId)
        {
            Obrt od = new Obrt();
            od.NazivObrta = "LH PROGRAMMING";
            od.ObrtOpis = "obrt za USLUGE";
            od.Vlasnik = "Zlatko Herzl";
            od.Ulica = "Ulica Platana";
            od.KucniBroj = "2";
            od.PostanskiBroj = "10000";
            od.Grad = "Zagreb";
            od.OIB = "89485468009";
            od.ZiroRacun = "HR5124840081107499065";
            od.UserId = userId;
            return od;
        }


        public List<Klijent> Klijenti(int userId)
        {
            List<Klijent> klijenti = new List<Klijent>();
            klijenti.Add(CreateObrtKlijentAlgebra(userId));
            klijenti.Add(CreateObrtKlijentVUA(userId));
            return klijenti;
        }

        private Klijent CreateObrtKlijentAlgebra(int userId)
        {
            Klijent ok = new Klijent();
            ok.NazivKlijenta = "Algebra d.o.o.";
            ok.Ulica = "Maksimirska";
            ok.KucniBroj = "58a";
            ok.PostanskiBroj = "10000";
            ok.Grad = "Zagreb";
            ok.OIB = "24919984448";
            ok.UserId = userId;
            return ok;
        }

        private Klijent CreateObrtKlijentVUA(int userId)
        {
            Klijent ok = new Klijent();
            ok.NazivKlijenta = "Visoko Učilište Algebra";
            ok.Ulica = "Ilica";
            ok.KucniBroj = "212";
            ok.PostanskiBroj = "10000";
            ok.Grad = "Zagreb";
            ok.OIB = "14575159920";
            ok.UserId = userId;
            return ok;
        }

        public FooterTemplate RacunFooter(int userId)
        {
            FooterTemplate rf = new FooterTemplate();
            rf.PdvInfo = "Izdavatelj računa nije obveznik poreza na dodanu vrijednost sukladno čl. 90. st. 2. Zakona o porezu na dodanu vrijednost (NN 73/13).";
            rf.UplataInfo = "Uplatu izvršiti na žiro račun broj {0}. U rubriku poziv na broj molimo upišite broj računa.";
            rf.UserId = userId;
            return rf;
        }

        public Racun JedanRacun(int userId, FooterTemplate footer, string ziro, Klijent k)
        {
            Racun r = new Racun();
            r.BrojRacuna = "2016-01";
            r.DatumVrijeme = DateTime.Now.AddDays(-365);
            r.FiskalniBrojRacuna = "1/1/1";
            r.FooterCijenaSlovima = "devetišestokn";
            r.FooterPdvInfo = footer.PdvInfo;
            r.FooterUplataInfo = footer.UplataInfo;
            r.OznakaOperatera = "ZH";
            r.ZiroRacun = ziro;
            r.Mjesto = "Zagreb";
            r.IznosRacuna = 9600;
            r.UserId = userId;
            r.Klijent = k;
            
            return r;
        }

        public Stavka JednaStavka(int userId, int racunId)
        {
            Stavka s = new Stavka();
            s.UslugaOpis = "Rad na ALPS sustavu od 01.11.2016-30.11.2016. prema ugovoru o suradnji od 01.11.2016.";
            s.UserId = userId;
            s.RacunId = racunId;
            s.Kolicina = 1;
            s.Cijena = 9600;
            s.RacunId = racunId;

            return s;
        }
    }
}