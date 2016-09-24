using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace EBudget.Models
{
    public class DetaljiTrosakPrihodModelView
    {
        UsersContext db = new UsersContext();
        public List<PrihodTrosak> trosakKolekcija;
        public List<PrihodTrosak> prihodKolekcija;


        public DetaljiTrosakPrihodModelView()
        {
            List<PrihodTrosak> lista = db.PrihodTrosak.Include("Kategorija").ToList();
            trosakKolekcija = new List<PrihodTrosak>();
            prihodKolekcija = new List<PrihodTrosak>();

            foreach (var item in lista)
            {
                if(item.UserId ==WebSecurity.CurrentUserId  && item.Kategorija.TipKategorijaID ==1)
                {
                    trosakKolekcija.Add(item);
                }
                else if (item.UserId == WebSecurity.CurrentUserId && item.Kategorija.TipKategorijaID == 2)
                {
                    prihodKolekcija.Add(item);
                }
            }

            
            
            
        }
    }
}