namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentexclude : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.comments", "parentComment", "dbo.comments");
            DropForeignKey("dbo.comments", "article_id1", "dbo.articles");
            DropIndex("dbo.comments", new[] { "parentComment" });
            DropIndex("dbo.comments", new[] { "article_id1" });
            DropTable("dbo.comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        article_id = c.Int(nullable: false),
                        comment_text = c.String(),
                        status = c.Boolean(nullable: false),
                        parentComment = c.Int(),
                        article_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.comments", "article_id1");
            CreateIndex("dbo.comments", "parentComment");
            AddForeignKey("dbo.comments", "article_id1", "dbo.articles", "id");
            AddForeignKey("dbo.comments", "parentComment", "dbo.comments", "id");
        }
    }
}
