using eBudgetPro;
using eBudgetPro.ResourcesFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace eBudgetPro.Models
{


    [Table("dbo.Category")]
    public class Category
    {
        public Category()
        {
            Amounts = new HashSet<Amount>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCategory { get; set; }

        [Range(0, int.MaxValue, ErrorMessageResourceType= typeof(Resource), ErrorMessageResourceName = "UserIDError")]
        public int UserID { get; set; }

        public int CategoryTypeID { get; set; }

        //[ForeignKey("CategoryTypeID")]
        public virtual CategoryType CategoryType { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "CategoryName")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredFieldGeneric")]
        [StringLength(70, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "CategoryNameError")]
        public string CategoryName { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "InUse")]
        public bool InUse { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredFieldGeneric")]
        [Display(ResourceType = typeof(Resource), Name = "EntryDateDisplay")]
        public DateTime EntryDate { get; set; }
        public ICollection<Amount> Amounts { get; set; }
    }




    [Table("dbo.CategoryType")]
    public class CategoryType
    {
        public CategoryType()
        {
            Categories = new HashSet<Category>();
        }

        // Category type can be only expense or income
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCatType { get; set; }
        
        [StringLength(10)]
        [Display(ResourceType = typeof(Resource), Name = "CategoryType")]
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }





    [Table("dbo.Amount")]
    public class Amount
    {
        public Amount()
        {
            if (EntryDate == null)
            {
                EntryDate = DateTime.Now;
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAmount { get; set; }

        [Required]
        public int UserID { get; set; }


        //[Range(0.01, Double.MaxValue, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ValidationAmountRange")]
        [DataType(DataType.Currency)]
        [Display(ResourceType = typeof(Resource), Name = "ValidationAmountDisplay")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "AmountRequired")]
        public decimal AmountValue { get; set; }

        
        [Display(ResourceType = typeof(Resource), Name = "CategoryType")]
        public int CategoryID { get; set; }

        //[ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        
        
        [Display(ResourceType = typeof(Resource), Name = "CurrencyDisplay")]
        public int CurrencyID { get; set; }



        //[ForeignKey("CurrencyID")]
        public virtual Currency Currency { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Description")]
        public string Description { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "InUse")]
        public bool InUse { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredFieldGeneric")]
        [Display(ResourceType = typeof(Resource), Name = "EntryDateDisplay")]
        public DateTime EntryDate { get; set; }
    }





    [Table("dbo.Currency")]
    public class Currency
    {
        public Currency()
        {
            Amounts = new HashSet<Amount>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCurrency { get; set; }

        public string CurrencyLabel { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        //public ICollection<Category> Categories { get; set; }
        public virtual ICollection<Amount> Amounts { get; set; }

    }



    public class Saldo
    {
        public int Year { get; set; }
        public string Month { get; set; }
        public decimal Sum { get; set; }
        public string Currency { get; set; }
    }

    public class HomeChartData
    {
        public string DateOfAmount { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        public decimal Balance { get; set; }
        public decimal BalanceCum { get; set; }
        public string Currency { get; set; }
    }
    



   

}
