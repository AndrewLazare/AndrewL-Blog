namespace AndrewL_Blog.Migrations
{
    using AndrewL_Blog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AndrewL_Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AndrewL_Blog.Models.ApplicationDbContext context)
        {

            //if (!System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Launch();
            var roleManager = new RoleManager<IdentityRole>(
                              new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "avlazareii@outlook.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "avlazareii@outlook.com",          /* these are property value pairs*/
                    Email = "avlazareii@outlook.com",
                    FirstName = "Andrew",
                    LastName = "Lazare",
                    DisplayName = "Andrew Lazare"
                }, "pooPoo1987!");
            }


            #region Assign Roles to users

            var adminId = userManager.FindByEmail("avlazareii@outlook.com").Id;    //it conducts a search leveraging the userManager and FindById...when its done its sitting on the record and I only want the id...so i put .id
            userManager.AddToRole(adminId, "Admin");

            #endregion
            if (!context.Users.Any(u => u.Email == "JasonModerator@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "JasonModerator@mailinator.com",          /* these are property value pairs*/
                    Email = "JasonModerator@mailinator.com",
                    FirstName = "Jason",
                    LastName = "Twitchell",
                    DisplayName = "Jason Twitchell"
                }, "Abc&123");
            }


            #region Assign Roles to users

            var moderatorId = userManager.FindByEmail("JasonModerator@mailinator.com").Id;    //it conducts a search leveraging the userManager and FindById...when its done its sitting on the record and I only want the id...so i put .id
            userManager.AddToRole(moderatorId, "Moderator");

            #endregion

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

    }
}
