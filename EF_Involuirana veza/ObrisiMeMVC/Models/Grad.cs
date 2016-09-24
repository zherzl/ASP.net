namespace ObrisiMeMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grad")]
    [Serializable]
    public partial class Grad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grad()
        {
            //Kupacs = new HashSet<Kupac>();
        }

        [Key]
        public int IDGrad { get; set; }

        [StringLength(50)]
        public string Naziv { get; set; }

        public int? DrzavaID { get; set; }

        public virtual Drzava Drzava { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Kupac> Kupacs { get; set; }
    }
}
