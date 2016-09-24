namespace WCFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Kupac")]
    [DataContract(IsReference = true)]
    public partial class Kupac
    {
        [Key]
        [DataMember] public int IDKupac { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember] public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember] public string Prezime { get; set; }

        [StringLength(50)]
        [DataMember] public string Email { get; set; }

        [StringLength(25)]
        [DataMember] public string Telefon { get; set; }
        [DataMember]
        public int? GradID { get; set; }
        [DataMember] public virtual Grad Grad { get; set; }
    }
}
