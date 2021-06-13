// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityProvider;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new ProfileWithRoleIdentityResource(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                // the api requires the role claim
                new ApiResource("api1", "MY API") //, new[] { JwtClaimTypes.Role }
                {
                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.Role,
                        "bandname"
                    }
                }
                //new ApiResource("dataequipment", "Data.Equipment", new[] { JwtClaimTypes.Role })
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            { 
                new Client {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "api1" }
            },
                new Client
                {
                    ClientId = "blazor",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:20001" },
                    AllowedScopes = { "openid", "profile", "email", "api1" },
                    RedirectUris = { "https://localhost:20001/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:20001/" },
                    Enabled = true
                },
            };
    }
}