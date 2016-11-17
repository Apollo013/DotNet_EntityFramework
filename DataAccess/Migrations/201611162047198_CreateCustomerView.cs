namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateCustomerView : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"CREATE VIEW Sales.CustomerView
                 AS
                 SELECT Id, Name, WorkEmail, WorkPhone FROM dbo.Customers"
            );
        }

        public override void Down()
        {
            Sql("DROP VIEW Sales.CustomerView");
        }
    }
}
