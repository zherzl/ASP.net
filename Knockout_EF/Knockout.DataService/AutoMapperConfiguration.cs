using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knockout.DataService.ViewModels;
using Knockout.Repository.EF.Models;
using AutoMapper;

namespace Knockout.DataService
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Grad, DrzavaGradViewModel>()
                .ForMember(dest => dest.DrzavaNaziv, opt => opt.MapFrom(src => src.Drzava.Naziv));
            });
        }
    }
}
