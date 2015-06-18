namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rental",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                        Rental_Date = c.DateTime(nullable: false),
                        Due_Date = c.DateTime(nullable: false),
                        Overdue_Fee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        Release_Year = c.Int(nullable: false),
                        Language = c.String(),
                        Rental_Fee = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MovieID = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rental", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.Inventory", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.Rental", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Inventory", new[] { "MovieID" });
            DropIndex("dbo.Rental", new[] { "MovieID" });
            DropIndex("dbo.Rental", new[] { "CustomerID" });
            DropTable("dbo.Inventory");
            DropTable("dbo.Movie");
            DropTable("dbo.Rental");
            DropTable("dbo.Customer");
        }
    }
}
