using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knockout.DataService.ViewModels;
using Knockout.Repository.EF.Models;

namespace Knockout.DataService.Mapping
{
    public static class GradViewMapper
    {
        public static List<DrzavaGradViewModel> ToGradViewModel(this List<Grad> gradovi)
        {
            var gradoviVm = AutoMapper.Mapper.Map<List<Grad>, List<DrzavaGradViewModel>>(gradovi);
            return gradoviVm;
        }
    }
}
