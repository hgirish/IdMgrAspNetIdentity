using Microsoft.AspNet.Identity.EntityFramework;

namespace IdMgrAspnetIdentity.IdentityConfig
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext ctx)
            : base(ctx)
        {
        }
    }
}