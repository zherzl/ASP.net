using Knockout.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knockout.DataService.Messaging.Response
{
    [Serializable]
    public class GradoviResponse
    {
        public List<DrzavaGradViewModel> GradoviModel { get; set; }
    }
}
