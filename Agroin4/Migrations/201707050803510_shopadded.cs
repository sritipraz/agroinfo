namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.shops",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shop_name = c.String(),
                        district_id = c.Int(nullable: false),
                        address = c.String(),
                        contact = c.Long(nullable: false),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.shops");
        }
    }
}
