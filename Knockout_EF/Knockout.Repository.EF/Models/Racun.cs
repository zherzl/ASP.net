namespace Knockout.Repository.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Racun")]
    public partial class Racun
    {
        public Racun()
        {
            Stavke = new HashSet<Stavka>();
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

        [ForeignKey("KomercijalistID")]
        public virtual Komercijalist Komercijalist { get; set; }

        [ForeignKey("KreditnaKarticaID")]
        public virtual KreditnaKartica KreditnaKartica { get; set; }

        [ForeignKey("KupacID")]
        public virtual Kupac Kupac { get; set; }

        public virtual ICollection<Stavka> Stavke { get; set; }
    }
}
