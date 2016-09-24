namespace DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grad")]
    public partial class Grad
    {
        [Key]
        public int IDGrad { get; set; }

        [StringLength(50)]
        public string Naziv { get; set; }

        public int? DrzavaID { get; set; }

        public virtual Drzava Drzava { get; set; }
    }
}
