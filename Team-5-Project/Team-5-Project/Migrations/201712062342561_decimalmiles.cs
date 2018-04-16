namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalmiles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Miles", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Miles", c => c.Int(nullable: false));
        }
    }
}
