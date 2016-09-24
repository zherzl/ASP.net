namespace ServiceLayer.Models.AdvModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    [Table("Kupac")]
    public partial class Kupac
    {
        [DataMember]
        [Key]
        public int IDKupac { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Email { get; set; }

        [DataMember]
        [StringLength(25)]
        public string Telefon { get; set; }

        //[DataMember]
        //public int? GradID { get; set; }

        //[DataMember]
        //public virtual Grad Grad { get; set; }
    }
}
