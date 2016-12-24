namespace Knockout.Repository.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kupac")]
    public partial class Kupac
    {
        public Kupac()
        {
            Racuni = new HashSet<Racun>();
        }

        [Key]
        public int IDKupac { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(25)]
        public string Telefon { get; set; }

        public int? GradID { get; set; }

        [ForeignKey("GradID")]
        public virtual Grad Grad { get; set; }

        
        public virtual ICollection<Racun> Racuni { get; set; }
    }
}
