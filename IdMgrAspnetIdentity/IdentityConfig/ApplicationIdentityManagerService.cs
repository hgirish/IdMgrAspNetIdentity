﻿using IdentityManager.AspNetIdentity;
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
    }
}