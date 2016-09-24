namespace ServiceLayer.Models.AdvModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Drzava")]
    [DataContract(IsReference = true)]
    public partial class Drzava
    {
        public Drzava()
        {
            Gradovi = new HashSet<Grad>();
        }

        [DataMember] [Key]
        public int IDDrzava { get; set; }

        [DataMember] [StringLength(50)]
        public string Naziv { get; set; }

        [DataMember]
        public virtual ICollection<Grad> Gradovi { get; set; }
    }
}
