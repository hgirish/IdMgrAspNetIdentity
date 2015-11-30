using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdMgrAspnetIdentity.IdentityConfig
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        //public ApplicationDbContext(string connectionString)
        //    : base(connectionString)
        //{

        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("IdSrv");
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}