using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCore_Ajax_test.Models
{
    public class EF7Context : DbContext
    {
        public EF7Context(DbContextOptions<EF7Context> options) : base(options)
        { }

        
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
    }


    [Table("Drzava")]
    public class Drzava : EntityBase<int>
    {
        public Drzava()
        {
            Gradovi = new List<Grad>();
        }
        public string Naziv { get; set; }
        public List<Grad> Gradovi { get; set; }
    }

    [Table("Grad")]
    public class Grad : EntityBase<int>
    {
        public Grad()
        {
            Kupci = new List<Kupac>();
        }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
        public List<Kupac> Kupci { get; set; }
    }

    [Table("Kupac")]
    public class Kupac : EntityBase<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }



    public class EntityBase<T>
    {
        public T Id { get; set; }
    }
}