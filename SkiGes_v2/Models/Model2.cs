using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SkiGes_v2.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=SkiGes_Model")
        {
        }

        public virtual DbSet<Adresa> Adresa { get; set; }
        public virtual DbSet<Partie> Partie { get; set; }
        public virtual DbSet<Pensiune> Pensiune { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Utilizator> Utilizator { get; set; }

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
