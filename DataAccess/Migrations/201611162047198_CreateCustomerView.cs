namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateCustomerView : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"CREATE VIEW dbo.CustomerView
                 AS
                 SELECT Id, Name, WorkEmail, WorkPhone FROM dbo.Customers"
            );
        }

        public override void Down()
        {
            Sql("DROP VIEW dbo.CustomerView");
        }
    }
}
