using ServiceLayer.Messaging.GradoviService.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceLayer.Models.AdvModel;
using System.ServiceModel;

namespace ServiceLayer.Implementations
{
    [ServiceKnownType(typeof(Grad))]
    internal class GradoviService
    {
        AdvModels db = new AdvModels();

        [OperationContract]
        public GetGradoviResponse GetGradovi(GetGradoviRequest request)
        {
            GetGradoviResponse gradoviResponse = new GetGradoviResponse();
            gradoviResponse.Gradovi = db.Gradovi.ToList();
            return gradoviResponse;
        }

    }
}