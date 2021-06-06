namespace ShadFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartsandEmails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartsCollections",
                c => new
                    {
                        PartsCollectionId = c.Int(nullable: false, identity: true),
                        PartName = c.String(),
                        Quaunity = c.String(),
                        Price = c.String(),
                        Supplier = c.String(),
                        SupplierAddress = c.String(),
                    })
                .PrimaryKey(t => t.PartsCollectionId);
            
            AddColumn("dbo.Requests", "UserEmail", c => c.String());
            AddColumn("dbo.WalkInRequests", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WalkInRequests", "UserEmail");
            DropColumn("dbo.Requests", "UserEmail");
            DropTable("dbo.PartsCollections");
        }
    }
}
