using AutoMapper;
using System;
using WCFTest.Model;
using WCFTest.Model.ViewModels;

namespace WCFTest
{
    internal class MappingConfig
    {
        internal static void RegisterMaps()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<Kupac, KupacViewModel>()
                .ForMember(dest => dest.Drzava, opt => opt.MapFrom(src => src.Grad.Drzava.Naziv));
            });
        }
    }
}