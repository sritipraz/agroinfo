namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class articlecropchangadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.articles", "article_description", c => c.String());
            DropColumn("dbo.crops", "description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.crops", "description", c => c.String());
            DropColumn("dbo.articles", "article_description");
        }
    }
}
