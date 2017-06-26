namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cropadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.crops",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        crop_name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        topography_id = c.Int(nullable: false),
                        season_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.crops");
        }
    }
}
