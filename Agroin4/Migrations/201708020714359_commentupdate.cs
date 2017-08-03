namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.comments", "parentComment", "dbo.comments");
            DropIndex("dbo.comments", new[] { "parentComment" });
            DropColumn("dbo.comments", "parentComment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.comments", "parentComment", c => c.Int());
            CreateIndex("dbo.comments", "parentComment");
            AddForeignKey("dbo.comments", "parentComment", "dbo.comments", "id");
        }
    }
}
