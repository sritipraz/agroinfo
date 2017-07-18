namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableArticle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.comments", "article_id", c => c.Int());
            CreateIndex("dbo.comments", "article_id");
            AddForeignKey("dbo.comments", "article_id", "dbo.comments", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.comments", "article_id", "dbo.comments");
            DropIndex("dbo.comments", new[] { "article_id" });
            AlterColumn("dbo.comments", "article_id", c => c.Int(nullable: false));
        }
    }
}
