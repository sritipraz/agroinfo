namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name_comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.comments", "user_email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.comments", "user_email");
        }
    }
}
