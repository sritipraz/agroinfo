namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3added : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.crops", "description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.crops", "description", c => c.String(nullable: false));
        }
    }
}
