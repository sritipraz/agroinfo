namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentadded : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sub_comment");
            DropTable("dbo.comments");
        }
    }
}
