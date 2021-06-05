namespace ShadFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusApprovalsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceStatus", "ApprovalOfRequest", c => c.Boolean(nullable: false));
            AddColumn("dbo.DeviceStatus", "ApprovalOfCharge", c => c.Boolean(nullable: false));
            AddColumn("dbo.DeviceStatusWalkIns", "ApprovalOfCharge", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceStatusWalkIns", "ApprovalOfCharge");
            DropColumn("dbo.DeviceStatus", "ApprovalOfCharge");
            DropColumn("dbo.DeviceStatus", "ApprovalOfRequest");
        }
    }
}
