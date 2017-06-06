namespace Kolcen.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Zahtevi> Zahtevis { get; set; }
        public virtual DbSet<Zaposleni> Zaposlenis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zaposleni>()
                .HasMany(e => e.Zahtevis)
                .WithRequired(e => e.Zaposleni)
                .WillCascadeOnDelete(false);
        }
    }
}
