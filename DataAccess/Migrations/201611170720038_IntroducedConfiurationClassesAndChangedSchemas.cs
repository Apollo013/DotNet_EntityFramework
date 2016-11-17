namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntroducedConfiurationClassesAndChangedSchemas : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Customers", newSchema: "Sales");
            MoveTable(name: "dbo.SalesOrders", newSchema: "Sales");
            MoveTable(name: "dbo.CustomerView", newSchema: "Sales");
        }
        
        public override void Down()
        {
            MoveTable(name: "Sales.CustomerView", newSchema: "dbo");
            MoveTable(name: "Sales.SalesOrders", newSchema: "dbo");
            MoveTable(name: "Sales.Customers", newSchema: "dbo");
        }
    }
}
