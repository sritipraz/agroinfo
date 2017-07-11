namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somt1added : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.shops", "district_id");
            AddForeignKey("dbo.shops", "district_id", "dbo.districts", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.shops", "district_id", "dbo.districts");
            DropIndex("dbo.shops", new[] { "district_id" });
        }
    }
}
