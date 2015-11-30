using Microsoft.AspNet.Identity.EntityFramework;

namespace IdMgrAspnetIdentity.IdentityConfig
{
    public class ApplicationRoleStore : RoleStore<IdentityRole>
    {
        public ApplicationRoleStore(ApplicationDbContext ctx)
            : base(ctx)
        {
        }
    }
}