namespace ObrisiMeMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GlupaTablica")]
    public partial class GlupaTablica
    {
        public GlupaTablica()
        {
            GlupaTablicaPodredenih = new HashSet<GlupaTablica>();
        }

        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Ime { get; set; }

        [StringLength(50)]
        public string Prezime { get; set; }

        public int? IDNadredenog { get; set; }


        public virtual ICollection<GlupaTablica> GlupaTablicaPodredenih { get; set; }
        [ForeignKey("IDNadredenog")]
        public virtual GlupaTablica GlupaTablicaNadredenog { get; set; }
    }
}
