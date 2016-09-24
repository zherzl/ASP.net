namespace ServiceLayer.Models.AdvModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Grad")]
    [DataContract(IsReference = true)]
    public partial class Grad
    {
        public Grad()
        {
            //Kupci = new HashSet<Kupac>();
        }

        [DataMember] [Key] public int IDGrad { get; set; }
        [DataMember] [StringLength(50)] public string Naziv { get; set; }
        [DataMember] public int? DrzavaID { get; set; }
        [DataMember] public virtual Drzava Drzava { get; set; }
        [DataMember] public virtual ICollection<Kupac> Kupci { get; set; }
    }
}
