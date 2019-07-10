using EfCodeFirst.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace EfCodeFirst
{
    public class EfContext : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Abteilung> Abteilung { get; set; }

        //public EfContext() : base("Server=.;Database=EfCodeFirst;Trusted_Connection=true;")
        public EfContext() : base("name=myConString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Data.Entity.ModelConfiguration.Conventions.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Mitarbeiter>().ToTable("Employees");

            modelBuilder.Entity<Mitarbeiter>().Property(x => x.Name)
                                              .HasColumnName("🧦")
                                              .HasMaxLength(67)
                                              .IsRequired();

            //modelBuilder.Configurations.Add(new DepartmentConfig());
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    public class DepartmentConfig : EntityTypeConfiguration<Abteilung>
    {

        public DepartmentConfig()
        {
            ToTable("Departments");
            Property(x => x.Bezeichnung).HasColumnName("Desc 🖼");
        }
    }

}
