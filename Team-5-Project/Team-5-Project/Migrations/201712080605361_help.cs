namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class help : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerSearchViewModels", "PrimaryID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerSearchViewModels", "PrimaryID");
        }
    }
}
