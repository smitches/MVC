namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "LapChild_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "LapChild_Id");
            AddForeignKey("dbo.Tickets", "LapChild_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Tickets", "LapChild");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "LapChild", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Tickets", "LapChild_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "LapChild_Id" });
            DropColumn("dbo.Tickets", "LapChild_Id");
        }
    }
}
