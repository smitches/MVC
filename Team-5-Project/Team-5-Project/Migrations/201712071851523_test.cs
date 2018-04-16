namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ChildDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "SeniorDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "Internetyes", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "InternetDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "FirstClass", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "EarlyDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "EarlyDiscount");
            DropColumn("dbo.Tickets", "FirstClass");
            DropColumn("dbo.Tickets", "InternetDiscount");
            DropColumn("dbo.Tickets", "Internetyes");
            DropColumn("dbo.Tickets", "SeniorDiscount");
            DropColumn("dbo.Tickets", "ChildDiscount");
        }
    }
}
