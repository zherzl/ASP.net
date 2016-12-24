namespace Knockout.Repository.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Drzava")]
    public partial class Drzava
    {
        public Drzava()
        {
            Gradovi = new HashSet<Grad>();
        }

        [Key]
        public int IDDrzava { get; set; }

        [StringLength(50)]
        public string Naziv { get; set; }

        public virtual ICollection<Grad> Gradovi { get; set; }
    }
}
