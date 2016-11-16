namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        WorkEmail = c.String(),
                        HomeEmail = c.String(nullable: false, maxLength: 50),
                        WorkPhone = c.String(),
                        HomePhone = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.HomeEmail, unique: true, name: "UQX_CustomerEmail");
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderAmount = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => new { t.CustomerId, t.Id }, unique: true, name: "UQX_CustomerSalesOrder");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOrders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.SalesOrders", "UQX_CustomerSalesOrder");
            DropIndex("dbo.Customers", "UQX_CustomerEmail");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.Customers");
        }
    }
}
