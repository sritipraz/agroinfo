namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2added : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.crops", "topography_id");
            AddForeignKey("dbo.crops", "topography_id", "dbo.topographies", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.crops", "topography_id", "dbo.topographies");
            DropIndex("dbo.crops", new[] { "topography_id" });
        }
    }
}
