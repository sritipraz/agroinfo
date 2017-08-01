namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yes2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.articles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        article_name = c.String(),
                        crop_id = c.Int(nullable: false),
                        date_time = c.DateTime(nullable: false),
                        rating = c.Int(nullable: false),
                        expert_id = c.Guid(nullable: false),
                        expert_email = c.String(),
                        article_description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.articles");
        }
    }
}
