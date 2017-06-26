namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class district_topograhyadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.districts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        district_name = c.String(),
                        topography_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.topographies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        topography_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.topographies");
            DropTable("dbo.districts");
        }
    }
}
