using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace skyges.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Adresa> Adresas { get; set; }
        public virtual DbSet<Partie> Parties { get; set; }
        public virtual DbSet<Pensiune> Pensiunes { get; set; }
        public virtual DbSet<Utilizator> Utilizators { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresa>()
                .Property(e => e.oras)
                .IsUnicode(false);

            modelBuilder.Entity<Adresa>()
                .Property(e => e.strada)
                .IsUnicode(false);

            modelBuilder.Entity<Partie>()
                .Property(e => e.nume)
                .IsUnicode(false);

            modelBuilder.Entity<Partie>()
                .Property(e => e.orar)
                .IsUnicode(false);

            modelBuilder.Entity<Partie>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<Partie>()
                .Property(e => e.stare_partie)
                .IsUnicode(false);

            modelBuilder.Entity<Partie>()
                .Property(e => e.dificultate)
                .IsUnicode(false);

            modelBuilder.Entity<Pensiune>()
                .Property(e => e.nume)
                .IsUnicode(false);

            modelBuilder.Entity<Pensiune>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Pensiune>()
                .Property(e => e.telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizator>()
                .Property(e => e.nume)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizator>()
                .Property(e => e.prenume)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizator>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizator>()
                .Property(e => e.telefon)
                .IsUnicode(false);
        }
    }
}
