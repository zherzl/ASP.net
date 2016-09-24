using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFTest.Model;
using WCFTest.Model.ViewModels;
using AutoMapper.QueryableExtensions;


namespace WCFTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IServiceAdventureWorks
    {
        AdvModelDva db = new AdvModelDva();
        public Service1()
        {
            MappingConfig.RegisterMaps();
        }

        //[OperationContract]
        [ApplyDataContractResolver]
        public List<Grad> GetGradovi()
        {
            //using (AdvModelDva ctx = new AdvModelDva())
            //{
            //    return ctx.Gradovi.Include("Drzava").ToList();
            //}
            return db.Gradovi.ToList();
        }

        [ApplyDataContractResolver]
        public List<KupacViewModel> GetKupacViewModel()
        {
            List<KupacViewModel> Kupci = db.Kupci.ProjectTo<KupacViewModel>().ToList();
            return Kupci;
        }
    }
}
