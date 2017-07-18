namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upda_logadded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.logs", "topography_id");
            DropColumn("dbo.logs", "season_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.logs", "season_id", c => c.Int(nullable: false));
            AddColumn("dbo.logs", "topography_id", c => c.Int(nullable: false));
        }
    }
}
