namespace TestDatabase_CoreFirst.Migrations.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestDatabase_CoreFirst.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestDatabase_CoreFirst.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(TestDatabase_CoreFirst.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("SuperAdmin"))
                roleManager.Create(new IdentityRole("SuperAdmin"));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Guest"))
                roleManager.Create(new IdentityRole("Guest"));


            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if(userManager.FindByEmail("sankar.pk@hotmil.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "sankar.pk@hotmail.com",
                    UserName = "sankar"
                };
                var result = userManager.Create(user, "P@ssw0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail("sankar.pk@hotmail.com").Id, "SuperAdmin");
            }

            if (userManager.FindByEmail("pks@hotmil.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "pks@hotmail.com",
                    UserName = "pksFamily"
                };
                var result = userManager.Create(user, "P@ssw0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail("pks@hotmail.com").Id, "Admin");
            }

            if (userManager.FindByEmail("guest@hotmil.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "guest@hotmail.com",
                    UserName = "GuestUser"
                };
                var result = userManager.Create(user, "guest@123");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail("guest@hotmail.com").Id, "Guest");
            }
        }                  
    }
}


