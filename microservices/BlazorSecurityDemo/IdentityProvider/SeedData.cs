// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using IdentityProvider.Data;
using IdentityProvider.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace IdentityProvider
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySQL("server=localhost;database=salkadb.identity;user=root;password=Rolka7Sushi;"));

            services.AddIdentity<SalkaClient, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddClaimsPrincipalFactory<SalkaClientClaimsPrincipalFactory>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<SalkaClient>>();

                    var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    string[] roleNames = { "Admin", "Manager", "Member" };
                    foreach (var roleName in roleNames)
                    {
                        var roleExist = RoleManager.RoleExistsAsync(roleName).Result;
                        if (!roleExist)
                        {
                            //create the roles and seed them to the database: Question 1
                            var roleResult = RoleManager.CreateAsync(new IdentityRole(roleName)).Result;
                        }
                    }


                    var alice = userMgr.FindByNameAsync("alice").Result;
                    if (alice != null)
                    {
                        userMgr.DeleteAsync(alice);
                    }

                    alice = new SalkaClient
                    {
                        UserName = "alice",
                        Bandname = "muse"
                    };
                    var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(alice, new Claim[]{
                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim("bandname", alice.Bandname)
                    }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("alice created");

                    /*
                    if (alice == null)
                    {
                        
                    }
                    else
                    {
                        Log.Debug("alice already exists");
                    }
                    */

                    var bob = userMgr.FindByNameAsync("bob").Result;
                    if (bob != null)
                    {
                        userMgr.DeleteAsync(bob);
                    }

                    bob = new SalkaClient
                    {
                        UserName = "bob",
                        Bandname = "system of a down"
                    };
                    //var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                    result = userMgr.CreateAsync(bob, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddToRoleAsync(bob, "Admin").Result;

                    result = userMgr.AddClaimsAsync(bob, new Claim[]{
                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim("location", "somewhere"),
                        new Claim("bandname", bob.Bandname),
                        new Claim("role", "Admin")
                    }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("bob created");

                    /*
                    if (bob == null)
                    {
                        
                    }
                    else
                    {
                        Log.Debug("bob already exists");
                    }
                    */
                }
            }
        }
    }
}
