namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guidadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.articles", "expert_id", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.articles", "expert_id");
        }
    }
}
