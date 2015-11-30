using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdMgrAspnetIdentity.IdentityConfig
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore roleStore)
            : base(roleStore)
        {
        }
    }
}