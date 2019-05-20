using System.Data.Entity.Migrations;
using Pseez.DataAccessLayer.DataContext;

namespace Pseez.DataAccessLayer.Migrations.PseezEntMigration
{
    public class Configuration : DbMigrationsConfiguration<PseezEntDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Migrations\PseezEntMigration";
        }

        protected override void Seed(PseezEntDbContext context)
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

            var seedAdminEnt = new SeedAdminEnt();
            seedAdminEnt.CreateAdminEnterpriseUserAndRole();

            var seedCommon = new SeedCommon();
            seedCommon.AddRoles();

            var seedVisitRegistration = new SeedVisitRegistration();
            seedVisitRegistration.AddRoles();

            var seedPmbok = new SeedPmbok();
            seedPmbok.AddRoles();
            seedPmbok.AddProjectDocumentsNames();
        }
    }
}