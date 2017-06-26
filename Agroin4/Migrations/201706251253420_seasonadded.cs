namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seasonadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.seasondefs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        season_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.seasondefs");
        }
    }
}
