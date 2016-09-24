namespace LocalizationTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Amounts = new HashSet<Amount>();
        }

        [Key]
        public int IDCategory { get; set; }

        public int UserID { get; set; }

        public int CategoryTypeID { get; set; }

        [Required]
        [StringLength(70)]
        public string CategoryName { get; set; }

        public bool InUse { get; set; }

        public DateTime EntryDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Amount> Amounts { get; set; }

        public virtual CategoryType CategoryType { get; set; }
    }
}
