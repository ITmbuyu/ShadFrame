namespace ShadFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removalofwalkintime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WalkInRequests", "RequestDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WalkInRequests", "RequestDateTime", c => c.DateTime(nullable: false));
        }
    }
}
