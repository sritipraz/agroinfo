namespace Agroin4.ApplicationDBDirectory
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Agroin4.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"ApplicationDBDirectory";
            ContextKey = "Agroin4.Models.ApplicationDbContext";
        }

        protected override void Seed(Agroin4.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var role = new IdentityRole() { Id = "1", Name = "Admin" };
            var role1 = new IdentityRole() { Id = "2", Name = "Expert" };
            var role2 = new IdentityRole() { Id = "3", Name = "User" };

            if (!context.Roles.Any(p => p.Name == "Admin"))
                manager.Create(role);
            if (!context.Roles.Any(p => p.Name == "Expert"))
                manager.Create(role1);
            if (!context.Roles.Any(p => p.Name == "User"))
                manager.Create(role2);

        }
    }
}
