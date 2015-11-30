using System.Linq;
using System.Threading.Tasks;
using IdentityManager;
using IdentityManager.AspNetIdentity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdMgrAspnetIdentity.IdentityConfig
{
    public class ApplicationIdentityManagerService :
        AspNetIdentityManagerService<ApplicationUser, string, 
            IdentityRole, string>
    {
        public ApplicationIdentityManagerService(
            ApplicationUserManager userMgr, 
            ApplicationRoleManager roleMgr)
            : base(userMgr, roleMgr)
        {
        }

        public override async Task<IdentityManagerResult> AddUserClaimAsync(string subject, string type, string value)
        {
            var result = await base.AddUserClaimAsync(subject, type, value);
            if (!result.IsSuccess)
            {
                if (result.Errors != null) return new IdentityManagerResult<CreateResult>(result.Errors.ToArray());
            }
            if (type == RoleClaimType)
            {
                var key = ConvertUserSubjectToKey(subject);
                var status = await this.userManager.AddToRoleAsync(key, value);
                if (!status.Succeeded)
                {
                    if (result.Errors != null) return new IdentityManagerResult<CreateResult>(result.Errors.ToArray());
                }
            }

            return IdentityManagerResult.Success;
        }

        public override async Task<IdentityManagerResult> RemoveUserClaimAsync(string subject, string type, string value)
        {
            var result = await base.RemoveUserClaimAsync(subject, type, value);
            if (!result.IsSuccess)
            {
                if (result.Errors != null) return new IdentityManagerResult<CreateResult>(result.Errors.ToArray());
            }
            if (type == RoleClaimType)
            {
                var key = ConvertUserSubjectToKey(subject);
                var status = await this.userManager.RemoveFromRoleAsync(key, value);
                if (!status.Succeeded)
                {
                    if (result.Errors != null) return new IdentityManagerResult<CreateResult>(result.Errors.ToArray());
                }
            }

            return IdentityManagerResult.Success;
        }
    }
}