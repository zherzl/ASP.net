using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace EBudget.Models
{
    public class CreateTrosakView
    {

        private UsersContext db;

        public PrihodTrosak Trosak { get; set; }
        //public InicijalniPodaci InicijalniPodaci { get; set; }
        //public Kategorija Kategorija { get; set; }
        //public TipKategorija TipKategorija { get; set; }

        public List<SelectListItem> Kategorije { get; set; }

        public CreateTrosakView()
        {
            db = new UsersContext();
            var kategorije = db.Kategorija.Where(k => k.TipKategorijaID == 1 && k.UserId == WebSecurity.CurrentUserId).ToList();

            Kategorije = new List<SelectListItem>();

            foreach (var item in kategorije)
            {
                Kategorije.Add(new SelectListItem()
                {
                    Text = item.Naziv,
                    Value = item.IDKategorija.ToString()
                });
            }
        }
    }
}