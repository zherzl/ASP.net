﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Test.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdventureWorksOBPEntities : DbContext
    {
        public AdventureWorksOBPEntities()
            : base("name=AdventureWorksOBPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
    }
}
