namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaadded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.articles", "expert_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.articles", "expert_id", c => c.Int(nullable: false));
        }
    }
}
