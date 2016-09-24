namespace ObrisiMeMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Racun")]
    public partial class Racun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Racun()
        {
            Stavkas = new HashSet<Stavka>();
        }

        [Key]
        public int IDRacun { get; set; }

        public DateTime DatumIzdavanja { get; set; }

        [Required]
        [StringLength(25)]
        public string BrojRacuna { get; set; }

        public int KupacID { get; set; }

        public int? KomercijalistID { get; set; }

        public int? KreditnaKarticaID { get; set; }

        [StringLength(128)]
        public string Komentar { get; set; }

        public virtual Komercijalist Komercijalist { get; set; }

        public virtual KreditnaKartica KreditnaKartica { get; set; }

        public virtual Kupac Kupac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stavka> Stavkas { get; set; }
    }
}
