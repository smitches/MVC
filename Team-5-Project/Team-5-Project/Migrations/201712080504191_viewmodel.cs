namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerSearchViewModels",
                c => new
                    {
                        CustomerSearchViewModelID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AdvantageNumber = c.Int(),
                        MI = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Miles = c.Int(nullable: false),
                        SeatID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerSearchViewModelID)
                .ForeignKey("dbo.Seats", t => t.SeatID)
                .Index(t => t.SeatID);
            
            AddColumn("dbo.AspNetUsers", "CustomerSearchViewModel_CustomerSearchViewModelID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CustomerSearchViewModel_CustomerSearchViewModelID");
            AddForeignKey("dbo.AspNetUsers", "CustomerSearchViewModel_CustomerSearchViewModelID", "dbo.CustomerSearchViewModels", "CustomerSearchViewModelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerSearchViewModels", "SeatID", "dbo.Seats");
            DropForeignKey("dbo.AspNetUsers", "CustomerSearchViewModel_CustomerSearchViewModelID", "dbo.CustomerSearchViewModels");
            DropIndex("dbo.CustomerSearchViewModels", new[] { "SeatID" });
            DropIndex("dbo.AspNetUsers", new[] { "CustomerSearchViewModel_CustomerSearchViewModelID" });
            DropColumn("dbo.AspNetUsers", "CustomerSearchViewModel_CustomerSearchViewModelID");
            DropTable("dbo.CustomerSearchViewModels");
        }
    }
}
