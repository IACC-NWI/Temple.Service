using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Temple.Service.Database.Model;

namespace Temple.Service.Database
{
    public class TempleDbContext :DbContext, ITempleDbContext
    {
        public TempleDbContext()
            : base("templeDbConnectionString")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(14, 2));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Festival> Festivals { get; set; }
        public DbSet<OfferedService> OfferedServices { get; set; }
    }
}
