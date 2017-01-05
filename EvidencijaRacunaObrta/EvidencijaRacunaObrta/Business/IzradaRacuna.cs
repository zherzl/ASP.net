using EvidencijaRacunaObrta.Business.Request;
using EvidencijaRacunaObrta.Business.Response;
using EvidencijaRacunaObrta.Models.ObrtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Business
{
    public class RacunManager : ModelManagerBase
    {
        
        public RacunManager(EvidencijaContext db) : base(db)
        {
        }

        public CreateRacunResponse CreateRacun(CreateRacunRequest racunRequest)
        {
            CreateRacunResponse response = new CreateRacunResponse();

            try
            {
                db.Racuni.Add(racunRequest.ObrtRacun);
                db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message.ToLower().Contains("inner exc") ? ex.InnerException.Message : ex.Message;
            }

            return response;
        }

        
    }
}