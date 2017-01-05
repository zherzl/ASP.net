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
                db.DetaljiObrta.Add(CreateObrtDetalj(userId));
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
        public ObrtDetalj CreateObrtDetalj(int userId)
        {
            ObrtDetalj od = new ObrtDetalj();
            od.NazivObrta = "LH PROGRAMMING";
            od.ObrtOpis = "obrt za USLUGE";
            od.Vlasnik = "Zlatko Herzl";
            od.Ulica = "Ulica Platana";
            od.KucniBroj = "2";
            od.PostanskiBroj = "10000";
            od.Grad = "Zagreb";
            od.OIB = "89485468009";
            od.ZiroRacun = "HR5124840081107499065";
            
            return od;
        }


        public List<ObrtKlijent> Klijenti(int userId)
        {
            List<ObrtKlijent> klijenti = new List<ObrtKlijent>();
            klijenti.Add(CreateObrtKlijentAlgebra(userId));
            klijenti.Add(CreateObrtKlijentVUA(userId));
            return klijenti;
        }

        private ObrtKlijent CreateObrtKlijentAlgebra(int userId)
        {
            ObrtKlijent ok = new ObrtKlijent();
            ok.NazivKlijenta = "Algebra d.o.o.";
            ok.Ulica = "Maksimirska";
            ok.KucniBroj = "58a";
            ok.PostanskiBroj = "10000";
            ok.Grad = "Zagreb";
            ok.OIB = "24919984448";
            return ok;
        }

        private ObrtKlijent CreateObrtKlijentVUA(int userId)
        {
            ObrtKlijent ok = new ObrtKlijent();
            ok.NazivKlijenta = "Visoko Učilište Algebra";
            ok.Ulica = "Ilica";
            ok.KucniBroj = "212";
            ok.PostanskiBroj = "10000";
            ok.Grad = "Zagreb";
            ok.OIB = "14575159920";
            return ok;
        }

        public RacunFooter RacunFooter(int userId)
        {
            RacunFooter rf = new RacunFooter();
            rf.PdvInfo = "Izdavatelj računa nije obveznik poreza na dodanu vrijednost sukladno čl. 90. st. 2. Zakona o porezu na dodanu vrijednost (NN 73/13).";
            rf.UplataInfo = "Uplatu izvršiti na žiro račun broj {0}. U rubriku poziv na broj molimo upišite broj računa.";
            return rf;
        }
    }
}