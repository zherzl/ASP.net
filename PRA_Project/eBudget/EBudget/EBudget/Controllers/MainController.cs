using EBudget.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace EBudget.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private UsersContext db = new UsersContext();
        //
        // GET: /Main/

        public ActionResult Index()
        {
            ViewBag.User = this.User.Identity.Name;
            //ViewBag.ID = WebSecurity.CurrentUserId;


            return View("Index");
        }

        [HttpGet]
        public ActionResult CreatePrihod()
        {
            CreatePrihodView ptv = new CreatePrihodView();
            return View("CreatePrihod", ptv);
        }

        [HttpGet]
        public ActionResult CreateTrosak()
        {
            CreateTrosakView ptv = new CreateTrosakView();
            return View("CreateTrosak", ptv);
        }


        [HttpPost]
        public ActionResult CreatePrihod(CreatePrihodView cpt, String submit)
        {
            if (ModelState.IsValid)
            {

                //dodajem UserID na prihod
                cpt.Prihod.UserId = WebSecurity.CurrentUserId;
                cpt.Prihod.ValutaID = 1; //HR
                cpt.Prihod.Aktivno = true;
                cpt.Prihod.KategorijaID = cpt.Prihod.Kategorija.IDKategorija;

                Repozitorij.SpremiPrihod(cpt.Prihod);


                switch (submit)
                {
                    case "finished":
                        return View("Index");
                    case "notFinished":
                        CreatePrihodView cptNew = new CreatePrihodView();
                        ModelState.Clear();
                        return View(cptNew);
                    default:
                        break;
                }
            }

            CreatePrihodView cptErr = new CreatePrihodView();
            return View(cptErr);
        }
        [HttpPost]
        public ActionResult CreateTrosak(CreateTrosakView cpt, String submit)
        {
            if (ModelState.IsValid)
            {

                //dodajem UserID na trosak
                cpt.Trosak.UserId = WebSecurity.CurrentUserId;
                cpt.Trosak.ValutaID = 1; //HR
                cpt.Trosak.Aktivno = true;
                cpt.Trosak.KategorijaID = cpt.Trosak.Kategorija.IDKategorija;
                
                //cpt.Trosak.DatumVrijeme.ge

                Repozitorij.SpremiTrosak(cpt.Trosak);

                switch (submit)
                {
                    case "finished":
                        return View("Index");
                    case "notFinished":
                        CreateTrosakView cptNew = new CreateTrosakView();
                        ModelState.Clear();
                        return View(cptNew);
                    default:
                        break;
                }
            }

            CreateTrosakView cptErr = new CreateTrosakView();
            return View(cptErr);
        }


        public ActionResult Kategorija()
        {
            ViewBag.selectLista = new List<SelectListItem>() {
                new SelectListItem{Text = "Trošak", Value="1"},
                new SelectListItem{Text="Prihod", Value="2"}
            };

            return View("AddKategorija");
        }
        [HttpPost]
        public ActionResult AddKategorija(string txtKategorija, string ddlTip)
        {
            int userID = WebSecurity.CurrentUserId;
            Repozitorij.DodajKategoriju(txtKategorija, ddlTip, userID);

            return RedirectToAction("Index");
        }


        public ActionResult PromjenaPodataka()
        {
            return View();
        }

        public ActionResult Print()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCSV(DateTime? datumOd, DateTime? datumDo)
        {
            MemoryStream stream = new MemoryStream();
            if (datumOd.HasValue && datumOd.HasValue)
            {
                
               List<PrihodTrosak> listaPrihodaTroskova = db.PrihodTrosak.Include("Kategorija").Where(p => p.UserId == WebSecurity.CurrentUserId && (p.DatumVrijeme >= datumOd.Value && p.DatumVrijeme <= datumDo.Value)).ToList();
               if (listaPrihodaTroskova.Count > 0)
               {
                   stream = CreateCSVData(listaPrihodaTroskova);
                   return File(stream, "application/csv", "prihodi_troskovi.csv");
               }
            }
            else
            {
                List<PrihodTrosak> listaPrihodaTroskova = db.PrihodTrosak.Include("Kategorija").Where(p => p.UserId == WebSecurity.CurrentUserId).ToList();
                if (listaPrihodaTroskova.Count > 0)
                {
                    stream = CreateCSVData(listaPrihodaTroskova);
                    return File(stream, "application/csv", "prihodi_troskovi.csv");
                }

            }
            //List<PrihodTrosak> listaTroskova = db.PrihodTrosak.Where(p => p.Kategorija.TipKategorijaID == 1 && p.UserId == WebSecurity.CurrentUserId).ToList();


            return View("Index");

        }

        public ActionResult AzurirajPodatke(string ime)
        {
            Repozitorij.UpdateIme(WebSecurity.CurrentUserId, ime);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetDataForGraph(int? opt)
        {
            //1.dohvati sve kategorije usera
            var kategorije = db.PrihodTrosak.Include("Kategorija").Where(pt => pt.UserId == WebSecurity.CurrentUserId);
            //2.stavi te kategorije u Dictionary sa zbrojem
            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();
            foreach (var item in kategorije)
            {
                //var key = db.TipKategorija.First(tip => tip.IDTipKategorija == item.Kategorija.TipKategorijaID).Naziv.Trim();
                var key = item.Kategorija.Naziv.Trim();
                
                if (dict.ContainsKey(key))
                {
                    dict[key] = ((decimal)dict[key] + item.Iznos);
                }
                else
                {
                    dict.Add(key, item.Iznos);
                }

            }
            //3.napravi listu naziva i zbroja
            var data = new List<PrihodTrosakJ>();
            foreach (var item in dict)
            {
                data.Add(new PrihodTrosakJ { Kategorija = item.Key, Iznos = item.Value });
            }
            //4.vrati sve




            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetGraphicChart()
        {


            //return Json(1,JsonRequestBehavior.AllowGet);
            return View();
        }

        public class PrihodTrosakJ
        {
            public decimal Iznos { get; set; }
            public string Kategorija { get; set; }
        }

        public MemoryStream CreateCSVData(List<PrihodTrosak> listaPrihodaTroskova)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("OPIS,TIP,IZNOS,DATUM");
            sb.AppendLine();
            foreach (var item in listaPrihodaTroskova)
            {

                sb.Append(db.Kategorija.Include("TipKategorija").FirstOrDefault(k => k.IDKategorija == item.KategorijaID).TipKategorija.Naziv + ",");
                sb.Append(item.Kategorija.Naziv + ",");
                sb.Append(item.Iznos + ",");
                if (item.DatumVrijeme.HasValue)
                {
                    sb.Append(item.DatumVrijeme.Value.ToShortDateString() + ",");
                }
                else
                {
                    sb.Append("NULL,");
                }
                sb.AppendLine();

            }
            var byteArray = Encoding.UTF8.GetBytes(sb.ToString());
            var result = Encoding.UTF8.GetPreamble().Concat(byteArray).ToArray();
            var stream = new MemoryStream(result);

            return stream;
        }
    }
}
