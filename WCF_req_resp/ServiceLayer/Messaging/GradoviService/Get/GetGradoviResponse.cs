using ServiceLayer.Models.AdvModel;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServiceLayer.Messaging.GradoviService.Get
{
    [Serializable]
    public class GetGradoviResponse
    {
        [DataMember]
        public List<Grad> Gradovi { get; set; }
    }
}