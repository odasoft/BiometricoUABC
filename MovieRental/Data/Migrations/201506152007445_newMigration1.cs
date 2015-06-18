namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rental", name: "Rental_Date", newName: "RD");
            AlterColumn("dbo.Rental", "RD", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rental", "RD", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Rental", name: "RD", newName: "Rental_Date");
        }
    }
}
