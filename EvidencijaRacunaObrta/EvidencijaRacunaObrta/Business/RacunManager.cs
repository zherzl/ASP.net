using EvidencijaRacunaObrta.Business.Request;
using EvidencijaRacunaObrta.Business.Response;
using EvidencijaRacunaObrta.Models.ObrtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Business
{
    public class RacunManager : ModelManagerBase
    {
        
        public RacunManager(EvidencijaContext db, int userId) : base(db, userId)
        {
        }

        public CreateRacunResponse GetCreateRacunResponse(CreateRacunRequest request)
        {
            CreateRacunResponse response = new CreateRacunResponse();

            try
            {
                if (request.RacunId.HasValue)
                    response.Racun = db.Racuni.FirstOrDefault(x => x.Id == request.RacunId);
                else // Uzimamo zadnji račun kao template
                    response.Racun = PripremiNoviRacun();

                response.Klijenti = db.Klijenti.Where(x => x.UserId == UserId).ToList();
                response.Templatei = db.FooteriRacuna.Where(x => x.UserId == UserId).ToList();

                Klijent k = response.Klijenti.FirstOrDefault(x => x.IsDefaultKlijent == true && x.UserId == UserId);
                FooterTemplate t = response.Templatei.FirstOrDefault(x => x.IsDefaultTemplate == true && x.UserId == UserId);

                if (k == null) k = response.Klijenti.FirstOrDefault(x => x.UserId == UserId);
                if (t == null) t = response.Templatei.FirstOrDefault(x => x.UserId == UserId);

                if (k == null || t == null)
                {
                    throw new Exception("Nema upisani niti jedan klijent ili podatak za footer");
                }

                response.DefaultKlijentId = k.Id;
                response.DefaultTemplateId = t.Id;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message.ToLower().Contains("inner exc") ? ex.InnerException.Message : ex.Message;
            }
            

            return response;
        }

        private Racun PripremiNoviRacun()
        {
            Obrt obrt = db.Obrti.FirstOrDefault(x => x.UserId == UserId);
            Racun tmp = db.Racuni.OrderByDescending(x => x.Id).Take(1).FirstOrDefault(x => x.UserId == UserId);
            Racun r = new Racun();
            string[] racun = tmp.BrojRacuna.Split('-');
            string[] fiskRacun = tmp.FiskalniBrojRacuna.Split('/');
            // radimo novu godinu
            int godinaRacuna = int.Parse(racun[0]);
            int brRacuna = int.Parse(racun[1]);
            int brFiskRacuna = int.Parse(fiskRacun[0]);

            if (godinaRacuna < DateTime.Now.Year)
            {
                godinaRacuna = DateTime.Now.Year;
                brRacuna = 1;
                brFiskRacuna = 1;
            }
            else
            {
                brRacuna++;
                brFiskRacuna++;
            }

            r.BrojRacuna = string.Format("{0}-{1:D2}", godinaRacuna, brRacuna);
            r.FiskalniBrojRacuna = string.Format("{0}/1/1", brFiskRacuna);
            r.DatumVrijeme = DateTime.Now;
            r.FooterCijenaSlovima = NumberTextConverter.NumberToText((double)tmp.IznosRacuna);
            r.FooterPdvInfo = tmp.FooterPdvInfo;
            r.FooterUplataInfo = string.Format(tmp.FooterUplataInfo, obrt.ZiroRacun);
            r.KlijentId = tmp.KlijentId;
            r.Mjesto = tmp.Mjesto;
            r.NacinPlacanja = tmp.NacinPlacanja;
            r.OznakaOperatera = tmp.OznakaOperatera;
            r.UserId = tmp.UserId;
            r.ValutaPlacanja = tmp.ValutaPlacanja;
            r.ZiroRacun = obrt.ZiroRacun;
            r.IznosRacuna = tmp.IznosRacuna;

            return r;
        }

        public CreateRacunInsertResponse InsertRacun(CreateRacunInsertRequest request)
        {
            CreateRacunInsertResponse response = new CreateRacunInsertResponse();

            try
            {
                List<FooterTemplate> templates = db.FooteriRacuna.ToList();
                SetAktivniTemplate(request.DefaultTemplateId);
                SetAktivniKlijent(request.DefaultKlijentId);
                db.Racuni.Add(request.Racun);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message.ToLower().Contains("inner exc") ? ex.InnerException.Message : ex.Message;
            }

            return response;
        }



        private void SetAktivniTemplate(int templateId)
        {
            // Tražimo aktivni template
            var templatei = db.FooteriRacuna.ToList();
            var aktTemplate = templatei.FirstOrDefault(x => x.Id == templateId);
            
            // Mijenjamo samo ako je nešto promijenjeno, zato ta sva logika ... što manje pisanja po bazi
            if (!aktTemplate.IsDefaultTemplate)
            {
                aktTemplate.IsDefaultTemplate = true;
                var otherTemplates = templatei.Where(x => x.Id != templateId).ToList();

                foreach (var item in otherTemplates)
                {
                    if (item.IsDefaultTemplate)
                        item.IsDefaultTemplate = false;
                }
            }
        }

        private void SetAktivniKlijent(int klijentId)
        {
            var klijenti = db.Klijenti.ToList();
            var aktKlijent = klijenti.FirstOrDefault(x => x.Id == klijentId);

            // Mijenjamo samo ako je nešto promijenjeno, zato ta sva logika ... što manje pisanja po bazi
            if (!aktKlijent.IsDefaultKlijent)
            {
                aktKlijent.IsDefaultKlijent = true;
                var otherClients = klijenti.Where(x => x.Id != klijentId).ToList();

                foreach (var item in otherClients)
                {
                    if (item.IsDefaultKlijent)
                        item.IsDefaultKlijent = false;
                }
            }
        }


        internal CreateStavkeResponse GetCreateStavkeResponse(CreateStavkeRequest request)
        {
            CreateStavkeResponse response = new CreateStavkeResponse();

            response.Stavka = new Stavka();
            if (request.StavkaId.HasValue)
            {
                response.Stavka = db.Stavke.Find(request.StavkaId);
            }

            return response;
        }

        public GetTop10StavkeResponse GetTop10StavkeResponse(GetTop10StavkeRequest request)
        {
            GetTop10StavkeResponse response = new GetTop10StavkeResponse();
            List<Stavka> tmp = db.Stavke.Where(x => x.UserId == UserId).OrderByDescending(x => x.Id).Take(10).ToList();
            foreach (var item in tmp)
            {
                item.Racun = new Racun();
                response.Stavke.Add(item);
            }
            return response;
        }
    }
}