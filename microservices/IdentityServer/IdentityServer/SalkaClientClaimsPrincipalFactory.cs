using IdentityProvider.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityProvider
{
    public class SalkaClientClaimsPrincipalFactory : UserClaimsPrincipalFactory<SalkaClient>
    {
        public SalkaClientClaimsPrincipalFactory(
        UserManager<SalkaClient> userManager,
        IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(SalkaClient user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("bandname", user.Bandname));
            return identity;
        }
    }
}
