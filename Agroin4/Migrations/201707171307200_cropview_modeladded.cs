namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cropview_modeladded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.crops", "Season_id", c => c.Int());
            CreateIndex("dbo.crops", "Season_id");
            AddForeignKey("dbo.crops", "Season_id", "dbo.seasondefs", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.crops", "Season_id", "dbo.seasondefs");
            DropIndex("dbo.crops", new[] { "Season_id" });
            AlterColumn("dbo.crops", "Season_id", c => c.Int(nullable: false));
        }
    }
}
