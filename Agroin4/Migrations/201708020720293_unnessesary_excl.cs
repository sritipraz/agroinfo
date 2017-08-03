namespace Agroin4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unnessesary_excl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.registration_tb", "type_id", "dbo.typedefs");
            DropIndex("dbo.registration_tb", new[] { "type_id" });
            DropTable("dbo.login_as");
            DropTable("dbo.logs");
            DropTable("dbo.registration_tb");
            DropStoredProcedure("dbo.registration_tb_Insert");
            DropStoredProcedure("dbo.registration_tb_Update");
            DropStoredProcedure("dbo.registration_tb_Delete");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.registration_tb",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone_no = c.String(),
                        type_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.logs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        farmer_id = c.Int(nullable: false),
                        qa_id = c.Int(nullable: false),
                        crop_id = c.Int(nullable: false),
                        production_quantity = c.Int(nullable: false),
                        production_area = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.login_as",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.registration_tb", "type_id");
            AddForeignKey("dbo.registration_tb", "type_id", "dbo.typedefs", "id", cascadeDelete: true);
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
