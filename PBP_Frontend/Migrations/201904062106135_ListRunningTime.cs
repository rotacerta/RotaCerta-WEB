namespace PBP_Frontend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListRunningTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "RunningTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Lists", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Lists", "Requester", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ListStatus", "Status", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ListStatus", "Status", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Lists", "Requester", c => c.String());
            AlterColumn("dbo.Lists", "Name", c => c.String());
            DropColumn("dbo.Lists", "RunningTime");
        }
    }
}
