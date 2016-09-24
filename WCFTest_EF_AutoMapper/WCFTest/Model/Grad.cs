namespace WCFTest.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;


    [Table("Grad")]
    [DataContract(IsReference= true)]
    [Serializable]
    public partial class Grad
    {
        public Grad()
        {
        }

        [Key]
        [DataMember]
        public int IDGrad { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Naziv { get; set; }

        [DataMember]
        public int? DrzavaID { get; set; }

        [DataMember]
        
        public virtual Drzava Drzava { get; set; }
    }
}
