namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useremail_article : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.articles", "expert_email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.articles", "expert_email");
        }
    }
}
