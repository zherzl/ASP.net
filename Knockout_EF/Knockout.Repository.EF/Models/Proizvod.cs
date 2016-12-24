namespace Knockout.Repository.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proizvod")]
    public partial class Proizvod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proizvod()
        {
            Stavkas = new HashSet<Stavka>();
        }

        [Key]
        public int IDProizvod { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(25)]
        public string BrojProizvoda { get; set; }

        [StringLength(15)]
        public string Boja { get; set; }

        public short MinimalnaKolicinaNaSkladistu { get; set; }

        [Column(TypeName = "money")]
        public decimal CijenaBezPDV { get; set; }

        public int? PotkategorijaID { get; set; }

        public virtual Potkategorija Potkategorija { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stavka> Stavkas { get; set; }
    }
}
