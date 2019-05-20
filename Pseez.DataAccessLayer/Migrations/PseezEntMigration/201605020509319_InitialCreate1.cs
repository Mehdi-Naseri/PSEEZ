namespace Pseez.DataAccessLayer.Migrations.PseezEntMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Cmms.Request", "RequestByName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Cmms.Request", "RequestByName", c => c.String());
        }
    }
}
