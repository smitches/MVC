namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cities", "CityIndex");
            DropIndex("dbo.Cities", "AirportIndex");
            AlterColumn("dbo.Cities", "CityName", c => c.String());
            AlterColumn("dbo.Cities", "Airport", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "Airport", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Cities", "CityName", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Cities", "Airport", unique: true, name: "AirportIndex");
            CreateIndex("dbo.Cities", "CityName", unique: true, name: "CityIndex");
        }
    }
}
