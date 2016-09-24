using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTest.Model.ViewModels
{
    public class KupacViewModel
    {
        [Key]
        [DataMember]
        public int IDKupac { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        public string Prezime { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Email { get; set; }

        [StringLength(25)]
        [DataMember]
        public string Telefon { get; set; }
        [DataMember]
        public int? GradID { get; set; }
        [DataMember]
        public virtual Grad Grad { get; set; }
        public string Drzava { get; set; }
    }
}