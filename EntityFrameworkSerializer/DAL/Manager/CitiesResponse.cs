using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class CitiesResponse : ResponseBase
    {
        public List<Grad> Cities { get; set; }
    }
}
