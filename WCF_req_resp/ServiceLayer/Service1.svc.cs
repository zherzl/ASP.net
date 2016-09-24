using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiceLayer.Messaging.GradoviService.Get;
using ServiceLayer.Implementations;
using ServiceLayer.Models.AdvModel;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AdventureService : IAdventureService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        [ApplyDataContractResolver]
        public GetGradoviResponse GetGradovi(GetGradoviRequest request)
        {
            GradoviService gs = new GradoviService();
            return gs.GetGradovi(request);
        }

        [ApplyDataContractResolver]
        public List<Grad> GetGradoviEf()
        {
            AdvModels db = new AdvModels();
            return db.Gradovi.ToList();
        }
    }
}
