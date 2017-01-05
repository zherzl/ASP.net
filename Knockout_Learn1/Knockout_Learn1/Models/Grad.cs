namespace Knockout_Learn1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grad")]
    public partial class Grad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grad()
        {
            Kupacs = new HashSet<Kupac>();
        }

        [Key]
        public int IDGrad { get; set; }

        [StringLength(50)]
        public string Naziv { get; set; }

        public int? DrzavaID { get; set; }
        [ForeignKey("DrzavaID")]
        public virtual Drzava Drzava { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kupac> Kupacs { get; set; }

        public string Prikaz { get { return "Grad " + Naziv; } }
        public string NazivDrzave { get { return Drzava.Naziv; } }
    }
}
