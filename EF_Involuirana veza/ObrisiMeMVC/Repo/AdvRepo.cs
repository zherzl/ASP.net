using ObrisiMeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ObrisiMeMVC.Repo
{
    public class AdvRepo
    {
        public IEnumerable<Grad> Gradovi()
        {
            AdvModel db = new AdvModel();
            return db.Gradovi.ToList();
        }

        public IEnumerable<Drzava> Drzave()
        {
            AdvModel db = new AdvModel();
            return db.Drzave.ToList();
        }
    }
}