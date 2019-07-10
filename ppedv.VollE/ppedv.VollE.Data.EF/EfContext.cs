using ppedv.VollE.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.VollE.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Mannschaft> Mannschaft { get; set; }
        public DbSet<Spieler> Spieler { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Spiel> Spiel { get; set; }

        public EfContext(string conString) : base(conString)
        { }
        public EfContext() : this("Server=.;Database=VollE_dev;Trusted_Connection=true")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Table per Type Mapping
            modelBuilder.Entity<Person>().ToTable(nameof(Person));
            modelBuilder.Entity<Spieler>().ToTable(nameof(Model.Spieler));
            modelBuilder.Entity<Trainer>().ToTable(nameof(Model.Trainer));

            modelBuilder.Entity<Mannschaft>().HasMany(x => x.Spieler).WithMany(x => x.Mannschaft);

            modelBuilder.Entity<Mannschaft>()
                .HasMany(x => x.SpielAlsGast)
                .WithRequired(x => x.GastMannschaft)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mannschaft>()
                .HasMany(x => x.SpielAlsHeim)
                .WithRequired(x => x.HeimMannschaft)
                .WillCascadeOnDelete(false);

        }
    }
}
