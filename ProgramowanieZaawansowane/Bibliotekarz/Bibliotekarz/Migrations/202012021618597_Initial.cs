namespace Bibliotekarz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        PageCount = c.Int(nullable: false),
                        IsBorrowed = c.Boolean(nullable: false),
                        Borrower_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Borrower_Id)
                .Index(t => t.Borrower_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Borrower_Id", "dbo.Customers");
            DropIndex("dbo.Books", new[] { "Borrower_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.Books");
        }
    }
}
