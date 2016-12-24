using Knockout.Repository.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knockout.DataService.ViewModels
{
    [Serializable]
    public class DrzavaGradViewModel
    {
        public string DrzavaNaziv { get; set; }
        public string Naziv { get; set; }
        List<Kupac> Kupci { get; set; }
    }
}
