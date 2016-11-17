namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Sales.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Street = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        County = c.String(),
                        Country = c.String(nullable: false, maxLength: 50),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sales.Customers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Sales.Addresses", "Id", "Sales.Customers");
            DropIndex("Sales.Addresses", new[] { "Id" });
            DropTable("Sales.Addresses");
        }
    }
}
