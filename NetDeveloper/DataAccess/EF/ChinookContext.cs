using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EF
{
    class ChinookContext: DbContext
    {
        public ChinookContext():base("ChinookcnxEF")
        {
            Database.SetInitializer<ChinookContext>(null);
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
        public virtual DbSet<Artist> Artists { get; set; }
    }
}
