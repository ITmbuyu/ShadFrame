namespace ShadFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Approvals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "ApprovalOfRequest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Requests", "ApprovalOfCharge", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "ApprovalOfCharge");
            DropColumn("dbo.Requests", "ApprovalOfRequest");
        }
    }
}
