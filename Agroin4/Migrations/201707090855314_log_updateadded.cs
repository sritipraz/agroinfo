namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log_updateadded : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.logs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.logs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        farmer_id = c.Int(nullable: false),
                        qa_id = c.Int(nullable: false),
                        crop_id = c.Int(nullable: false),
                        district_id = c.Int(nullable: false),
                        production_quantity = c.Int(nullable: false),
                        production_area = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        season_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
