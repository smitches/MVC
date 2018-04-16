namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _319 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "MI", c => c.String(maxLength: 1));
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "MI", c => c.String());
        }
    }
}
