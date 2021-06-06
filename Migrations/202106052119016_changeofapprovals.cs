namespace ShadFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeofapprovals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovalMessages",
                c => new
                    {
                        ApprovalMessagesId = c.Int(nullable: false, identity: true),
                        AMessages = c.String(),
                    })
                .PrimaryKey(t => t.ApprovalMessagesId);
            
            CreateTable(
                "dbo.CApprovalMessages",
                c => new
                    {
                        CApprovalMessagesId = c.Int(nullable: false, identity: true),
                        CMessages = c.String(),
                    })
                .PrimaryKey(t => t.CApprovalMessagesId);
            
            AddColumn("dbo.Requests", "CApprovalMessagesId", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "ApprovalMessagesId", c => c.Int(nullable: false));
            AddColumn("dbo.WalkInRequests", "CApprovalMessagesId", c => c.Int(nullable: false));
            AlterColumn("dbo.DeviceStatus", "ApprovalOfRequest", c => c.String());
            AlterColumn("dbo.DeviceStatus", "ApprovalOfCharge", c => c.String());
            AlterColumn("dbo.DeviceStatusWalkIns", "ApprovalOfCharge", c => c.String());
            CreateIndex("dbo.Requests", "CApprovalMessagesId");
            CreateIndex("dbo.Requests", "ApprovalMessagesId");
            CreateIndex("dbo.WalkInRequests", "CApprovalMessagesId");
            AddForeignKey("dbo.Requests", "ApprovalMessagesId", "dbo.ApprovalMessages", "ApprovalMessagesId", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "CApprovalMessagesId", "dbo.CApprovalMessages", "CApprovalMessagesId", cascadeDelete: true);
            AddForeignKey("dbo.WalkInRequests", "CApprovalMessagesId", "dbo.CApprovalMessages", "CApprovalMessagesId", cascadeDelete: true);
            DropColumn("dbo.Requests", "ApprovalOfRequest");
            DropColumn("dbo.Requests", "ApprovalOfCharge");
            DropColumn("dbo.WalkInRequests", "ApprovelCharge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WalkInRequests", "ApprovelCharge", c => c.Boolean(nullable: false));
            AddColumn("dbo.Requests", "ApprovalOfCharge", c => c.Boolean(nullable: false));
            AddColumn("dbo.Requests", "ApprovalOfRequest", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.WalkInRequests", "CApprovalMessagesId", "dbo.CApprovalMessages");
            DropForeignKey("dbo.Requests", "CApprovalMessagesId", "dbo.CApprovalMessages");
            DropForeignKey("dbo.Requests", "ApprovalMessagesId", "dbo.ApprovalMessages");
            DropIndex("dbo.WalkInRequests", new[] { "CApprovalMessagesId" });
            DropIndex("dbo.Requests", new[] { "ApprovalMessagesId" });
            DropIndex("dbo.Requests", new[] { "CApprovalMessagesId" });
            AlterColumn("dbo.DeviceStatusWalkIns", "ApprovalOfCharge", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DeviceStatus", "ApprovalOfCharge", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DeviceStatus", "ApprovalOfRequest", c => c.Boolean(nullable: false));
            DropColumn("dbo.WalkInRequests", "CApprovalMessagesId");
            DropColumn("dbo.Requests", "ApprovalMessagesId");
            DropColumn("dbo.Requests", "CApprovalMessagesId");
            DropTable("dbo.CApprovalMessages");
            DropTable("dbo.ApprovalMessages");
        }
    }
}
