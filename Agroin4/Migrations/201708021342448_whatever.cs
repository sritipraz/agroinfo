namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatever : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.Guid(nullable: false),
                        user_email = c.String(),
                        comment_text = c.String(),
                        TimeOfPost = c.DateTime(nullable: false),
                        article_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.articles", t => t.article_id, cascadeDelete: true)
                .Index(t => t.article_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.comments", "article_id", "dbo.articles");
            DropIndex("dbo.comments", new[] { "article_id" });
            DropTable("dbo.comments");
        }
    }
}
