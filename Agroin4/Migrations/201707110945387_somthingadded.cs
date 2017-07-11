namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somthingadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.logs", "topography_id", c => c.Int(nullable: false));
            DropColumn("dbo.logs", "district_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.logs", "district_id", c => c.Int(nullable: false));
            DropColumn("dbo.logs", "topography_id");
        }
    }
}
