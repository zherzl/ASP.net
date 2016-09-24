namespace LocalizationTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Amount")]
    public partial class Amount
    {
        [Key]
        public int IDAmount { get; set; }

        public int UserID { get; set; }

        public decimal AmountValue { get; set; }

        public int CategoryID { get; set; }

        public int CurrencyID { get; set; }

        public string Description { get; set; }

        public bool InUse { get; set; }

        public DateTime EntryDate { get; set; }

        public virtual Category Category { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
