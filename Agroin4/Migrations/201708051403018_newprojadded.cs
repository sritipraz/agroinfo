namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newprojadded : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.typedefs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.typedefs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
