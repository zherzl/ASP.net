namespace WCFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Grad")]
    [DataContract(IsReference= true)]
    public partial class Grad
    {
        public Grad()
        {
            Kupci = new HashSet<Kupac>();
        }

        [Key]
        [DataMember] public int IDGrad { get; set; }

        [StringLength(50)]
        [DataMember] public string Naziv { get; set; }

        [DataMember] public int? DrzavaID { get; set; }

        [DataMember]  public virtual Drzava Drzava { get; set; }

        [DataMember] public virtual ICollection<Kupac> Kupci { get; set; }
    }
}
