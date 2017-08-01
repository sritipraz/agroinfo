namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.logs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        farmer_id = c.Int(nullable: false),
                        qa_id = c.Int(nullable: false),
                        crop_id = c.Int(nullable: false),
                        production_quantity = c.Int(nullable: false),
                        production_area = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.crops", "season_id");
            CreateIndex("dbo.shops", "district_id");
            AddForeignKey("dbo.crops", "season_id", "dbo.seasondefs", "id", cascadeDelete: true);
            AddForeignKey("dbo.shops", "district_id", "dbo.districts", "id", cascadeDelete: true);
            DropColumn("dbo.districts", "topography_id");
            DropTable("dbo.articles");
            DropTable("dbo.comments");
            DropTable("dbo.sub_comment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.sub_comment",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comment_id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        comment = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        article_id = c.Int(nullable: false),
                        comment_text = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.articles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        article_name = c.String(),
                        crop_id = c.Int(nullable: false),
                        date_time = c.DateTime(nullable: false),
                        rating = c.Int(nullable: false),
                        expert_id = c.Int(nullable: false),
                        article_description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.districts", "topography_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.shops", "district_id", "dbo.districts");
            DropForeignKey("dbo.crops", "season_id", "dbo.seasondefs");
            DropIndex("dbo.shops", new[] { "district_id" });
            DropIndex("dbo.crops", new[] { "season_id" });
            DropTable("dbo.logs");
        }
    }
}
