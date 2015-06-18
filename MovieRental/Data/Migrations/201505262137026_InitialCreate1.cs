namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movie", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Movie", "Language", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Language", c => c.String());
            AlterColumn("dbo.Movie", "Genre", c => c.String());
            AlterColumn("dbo.Movie", "Name", c => c.String());
            AlterColumn("dbo.Customer", "Email", c => c.String());
            AlterColumn("dbo.Customer", "LastName", c => c.String());
            AlterColumn("dbo.Customer", "FirstName", c => c.String());
        }
    }
}
