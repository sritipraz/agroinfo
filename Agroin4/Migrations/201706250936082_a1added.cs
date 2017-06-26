namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.login_as",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.login_as");
        }
    }
}
