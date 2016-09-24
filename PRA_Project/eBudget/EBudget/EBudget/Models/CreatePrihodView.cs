using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace EBudget.Models
{
    public class CreatePrihodView
    {
        private UsersContext db;

        public PrihodTrosak Prihod { get; set; }
        //public InicijalniPodaci InicijalniPodaci { get; set; }
        //public Kategorija Kategorija { get; set; }

        public List<SelectListItem> Kategorije { get; set; }

        public CreatePrihodView()
        {

            db = new UsersContext();
            var kategorije = db.Kategorija.Where(k => k.TipKategorijaID == 2 && k.UserId == WebSecurity.CurrentUserId).ToList();

            Kategorije = new List<SelectListItem>();

            foreach (var item in kategorije)
            {
                Kategorije.Add(new SelectListItem() { 
                    Text = item.Naziv,
                    Value = item.IDKategorija.ToString()
                });
            }

        }
    }
}