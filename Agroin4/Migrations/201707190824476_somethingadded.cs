namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingadded : DbMigration
    {
        public override void Up()
        {
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
            
        }
    }
}
