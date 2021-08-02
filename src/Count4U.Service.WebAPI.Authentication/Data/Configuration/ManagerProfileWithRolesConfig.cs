using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Count4U.Service.Core.Server.Data
{
        public class ManagerProfileWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
        {

        private const string managerProfileId = "74d87db4-22222-22222-22222-2b96e0ada52a";
        private const string ProfileRoleId = "38539cf9-77e9-4129-b6a6-9cfbbf3c64ac";


        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
                IdentityUserRole<string> iur = new IdentityUserRole<string>
                {
                    RoleId = ProfileRoleId,
                    UserId = managerProfileId
                };

                builder.HasData(iur);
            }
        }
    }
