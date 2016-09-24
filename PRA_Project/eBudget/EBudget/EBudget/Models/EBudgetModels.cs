using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EBudget.Models
{
    #region Konstruktor
    public class EBudgetModels
    {
    }
    #endregion

    [Table("Valuta")]
    public class Valuta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDValuta { get; set; }
        [DisplayName("Zemlja: ")]
        public string Zemlja { get; set; }
        [DisplayName("Oznaka: ")]
        public string Oznaka { get; set; }
        [DisplayName("Tečaj: ")]
        public decimal Tecaj { get; set; }
        [DisplayName("Datum: ")]
        public DateTime DatumVrijeme { get; set; }
        public bool Aktivno { get; set; }

        //Foreign key
        public int UserId { get; set; }
        //Lazy loader
        [ForeignKey("UserId")]
        public UserProfile UserProfile { get; set; }
    }

    [Table("InicijalnaValuta")]
    public class InicijalnaValuta
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInicijalnaValuta { get; set; }
        [DisplayName("Zemlja: ")]
        public string Zemlja { get; set; }
        [DisplayName("Oznaka: ")]
        public string Oznaka { get; set; }
    }

    [Table("Kategorija")]
    public class Kategorija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDKategorija { get; set; }
        [DisplayName("Naziv kategorije: ")]
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
        [DisplayName("Datum: ")]
        public DateTime DatumVrijeme { get; set; }

        //Foreign key
        public int TipKategorijaID { get; set; }
        //Lazy loader
        [ForeignKey("TipKategorijaID")]
        public TipKategorija TipKategorija { get; set; }
        //Foreign key
        public int UserId { get; set; }
        //Lazy loader
        [ForeignKey("UserId")]
        public UserProfile UserProfile { get; set; }
    }

    [Table("TipKategorija")]
    public class TipKategorija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTipKategorija { get; set; }
        [DisplayName("Tip kategorije: ")]
        public string Naziv { get; set; }
    }

    [Table("InicijalniPodaci")]
    public class InicijalniPodaci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInicijalniPodaci { get; set; }
        public string Naziv { get; set; }

        //Foreign key
        public int TipKategorijaID { get; set; }
        //Lazy loader
        [ForeignKey("TipKategorijaID")]
        public TipKategorija TipKategorija { get; set; }
    }

    [Table("PrihodTrosak")]
    public class PrihodTrosak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDPrihodTrosak { get; set; }
        [DisplayName("Iznos: ")]
        [Required(ErrorMessage="Broj obavezan za unos")]
        public decimal Iznos { get; set; }
        [DisplayName("Datum: ")]
        [Column(TypeName = "DateTime")]
        public DateTime? DatumVrijeme { get; set; }
        public bool Aktivno { get; set; }

        //Foreign key
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserProfile UserProfile { get; set; }
        public int KategorijaID { get; set; }
        [ForeignKey("KategorijaID")]
        public Kategorija Kategorija { get; set; }
        public int ValutaID { get; set; }
        [ForeignKey("ValutaID")]
        public Valuta Valuta { get; set; }
        //public int OpisID { get; set; }
        //[ForeignKey("OpisID")]
        //public Opis Opis { get; set; }      
    }

    [Table("Opis")]
    public class Opis
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDOpis { get; set; }
        [DisplayName("Opis: ")]
        public string Naziv { get; set; }

        public int PrihodTrosakID { get; set; }
        [ForeignKey("PrihodTrosakID")]
        public virtual PrihodTrosak PrihodTrosak { get; set; }
    }

}