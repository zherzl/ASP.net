namespace Probica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stavka")]
    public partial class Stavka
    {
        [Key]
        public int IDStavka { get; set; }

        public int RacunID { get; set; }

        public short Kolicina { get; set; }

        public int ProizvodID { get; set; }

        [Column(TypeName = "money")]
        public decimal CijenaPoKomadu { get; set; }

        [Column(TypeName = "money")]
        public decimal PopustUPostocima { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UkupnaCijena { get; set; }

        public virtual Racun Racun { get; set; }
    }
}
