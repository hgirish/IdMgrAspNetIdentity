using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdMgrAspnetIdentity.IdentityConfig
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, 
                DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            foreach (var claim in userIdentity.Claims.Where(x=>x.Type == IdentityManager.Constants.ClaimTypes.Role))
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, claim.Value));
            }
           
            return userIdentity;
        }
        public string First { get; set; }
        public bool IsNice { get; set; }
        public int Age { get; set; }
    }
}