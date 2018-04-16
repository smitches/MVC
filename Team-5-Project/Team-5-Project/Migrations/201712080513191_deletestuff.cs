namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletestuff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerSearchViewModels", "DOB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerSearchViewModels", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
