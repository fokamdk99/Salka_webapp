// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel;
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

                // let's include the role claim in the profile
                new ProfileWithRoleIdentityResource(),
                new IdentityResources.Email()
            };

        /*
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { new ApiScope("api1", "My API") };
        */

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                // the api requires the role claim
                new ApiResource("weatherapi", "The Weather API") //, new[] { JwtClaimTypes.Role }
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
             new Client
                {
                    ClientId = "blazor",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:5001" },
                    AllowedScopes = { "openid", "profile", "email", "weatherapi" },
                    RedirectUris = { "https://localhost:5001/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5001/" },
                    Enabled = true
                },
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "openid", "profile", "email", "weatherapi" },
                } 
            };

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("weatherapi", "The Weather API") //, new[] { JwtClaimTypes.Role }
                {
                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.Role,
                        "bandname"
                    },
                    Scopes = new List<string>()
                    {
                        "weatherapi"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope(name: "weatherapi",   displayName: "weatherapi backend")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),

                // let's include the role claim in the profile
                new ProfileWithRoleIdentityResource(),
                new IdentityResources.Email()
            };
        }
    }
}