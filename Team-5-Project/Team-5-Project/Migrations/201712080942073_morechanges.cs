namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morechanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "MI", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "MI", c => c.String(maxLength: 1));
        }
    }
}
