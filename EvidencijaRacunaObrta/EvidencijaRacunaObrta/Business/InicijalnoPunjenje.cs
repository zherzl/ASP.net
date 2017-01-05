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
                db.Obrti.Add(CreateObrtDetalj(userId));
                db.Klijenti.AddRange(Klijenti(userId));
                db.FooteriRacuna.Add(RacunFooter(userId));
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
    }
}