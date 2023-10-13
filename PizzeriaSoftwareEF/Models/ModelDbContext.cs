using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PizzeriaSoftwareEF.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<DettaglioOrdini> DettaglioOrdini { get; set; }
        public virtual DbSet<NoteOrdini> NoteOrdini { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Clienti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordini>()
                .Property(e => e.Importo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ordini>()
                .HasMany(e => e.DettaglioOrdini)
                .WithRequired(e => e.Ordini)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordini>()
                .HasMany(e => e.NoteOrdini)
                .WithRequired(e => e.Ordini)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotti>()
                .Property(e => e.Costo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.DettaglioOrdini)
                .WithRequired(e => e.Prodotti)
                .WillCascadeOnDelete(false);
        }
    }
}
