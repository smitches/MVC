namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class god : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "LapChild_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "LapChild_Id" });
            AddColumn("dbo.Tickets", "LapChild", c => c.String());
            DropColumn("dbo.Tickets", "LapChild_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "LapChild_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Tickets", "LapChild");
            CreateIndex("dbo.Tickets", "LapChild_Id");
            AddForeignKey("dbo.Tickets", "LapChild_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
