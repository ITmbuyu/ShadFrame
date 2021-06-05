namespace ShadFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        BrandRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        ColourId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ColourId);
            
            CreateTable(
                "dbo.DeviceDescriptions",
                c => new
                    {
                        DeviceDescriptionId = c.Int(nullable: false, identity: true),
                        BrandId = c.Int(nullable: false),
                        DeviceName = c.String(),
                    })
                .PrimaryKey(t => t.DeviceDescriptionId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.DeviceProblems",
                c => new
                    {
                        DeviceProblemId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CostOfP = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceProblemId);
            
            CreateTable(
                "dbo.DeviceStatus",
                c => new
                    {
                        TrackingNumber = c.String(nullable: false, maxLength: 128),
                        Brand = c.String(),
                        DeviceProblem = c.String(),
                        DeviceName = c.String(),
                        Capacity = c.String(),
                        Colour = c.String(),
                        IMEI = c.String(),
                        Price = c.Double(nullable: false),
                        RepairStatusId = c.Int(nullable: false),
                        PaymentStatus = c.String(),
                        RequestDateTime = c.DateTime(nullable: false),
                        UserId = c.String(),
                        TechnicianId = c.String(),
                    })
                .PrimaryKey(t => t.TrackingNumber)
                .ForeignKey("dbo.RepairStatus", t => t.RepairStatusId, cascadeDelete: true)
                .Index(t => t.RepairStatusId);
            
            CreateTable(
                "dbo.RepairStatus",
                c => new
                    {
                        RepairStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RepairStatusId);
            
            CreateTable(
                "dbo.DeviceStatusWalkIns",
                c => new
                    {
                        TrackingNumber = c.String(nullable: false, maxLength: 128),
                        Brand = c.String(),
                        DeviceProblem = c.String(),
                        DeviceName = c.String(),
                        Capacity = c.String(),
                        Colour = c.String(),
                        IMEI = c.String(),
                        WalkInDate = c.DateTime(nullable: false),
                        WalkInTime = c.String(),
                        Price = c.Double(nullable: false),
                        WalkInStatus = c.String(),
                        RepairStatusId = c.Int(nullable: false),
                        PaymentStatus = c.String(),
                        RequestDateTime = c.DateTime(nullable: false),
                        UserId = c.String(),
                        TechnicianId = c.String(),
                    })
                .PrimaryKey(t => t.TrackingNumber)
                .ForeignKey("dbo.RepairStatus", t => t.RepairStatusId, cascadeDelete: true)
                .Index(t => t.RepairStatusId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmpName = c.String(nullable: false, maxLength: 30),
                        EmpSurname = c.String(nullable: false, maxLength: 30),
                        EmpEmail = c.String(nullable: false, maxLength: 50),
                        EmpPassword = c.String(nullable: false),
                        EmpRate = c.Double(nullable: false),
                        EmpHours = c.Int(nullable: false),
                        EmpWage = c.Double(nullable: false),
                        EmployeeRole = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartsId = c.Int(nullable: false, identity: true),
                        Part_Name = c.String(),
                        Part_Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PartsId);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        PaymentStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.PaymentStatusId);
            
            CreateTable(
                "dbo.RequestPayments",
                c => new
                    {
                        RequestPaymentsId = c.Int(nullable: false, identity: true),
                        paymentmethod = c.String(),
                        CardNumber = c.String(maxLength: 16),
                        CVVnumber = c.String(maxLength: 3),
                        ExpiryDate = c.DateTime(nullable: false),
                        UserId = c.String(),
                        DateTimeofpayment = c.DateTime(nullable: false),
                        TrackingNumberOfRequest = c.String(),
                        Priceofrepair = c.String(),
                    })
                .PrimaryKey(t => t.RequestPaymentsId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        DeviceProblemId = c.Int(nullable: false),
                        DeviceDescriptionId = c.Int(nullable: false),
                        StorageId = c.Int(nullable: false),
                        ColourId = c.Int(nullable: false),
                        IMEI = c.String(maxLength: 15),
                        Price = c.Double(nullable: false),
                        RequestDateTime = c.DateTime(nullable: false),
                        UserId = c.String(),
                        PaymentStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Colours", t => t.ColourId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceDescriptions", t => t.DeviceDescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceProblems", t => t.DeviceProblemId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentStatus", t => t.PaymentStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.DeviceProblemId)
                .Index(t => t.DeviceDescriptionId)
                .Index(t => t.StorageId)
                .Index(t => t.ColourId)
                .Index(t => t.PaymentStatusId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        StorageCapacity = c.String(),
                    })
                .PrimaryKey(t => t.StorageId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SupplierParts",
                c => new
                    {
                        SupplierPartId = c.Int(nullable: false, identity: true),
                        PartsId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        PartSupplied_Date = c.String(),
                        PartSupplied_Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierPartId)
                .ForeignKey("dbo.Parts", t => t.PartsId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.PartsId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Supplier_Name = c.String(),
                        Supplier_Address = c.String(),
                        Supplier_CellNumber = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WalkInPayments",
                c => new
                    {
                        WalkInPaymentsId = c.Int(nullable: false, identity: true),
                        paymentmethod = c.String(),
                        CardNumber = c.String(maxLength: 16),
                        CVVnumber = c.String(maxLength: 3),
                        ExpiryDate = c.DateTime(nullable: false),
                        UserId = c.String(),
                        DateTimeofpayment = c.DateTime(nullable: false),
                        TrackingNumberOfRequest = c.String(),
                        Priceofrepair = c.String(),
                    })
                .PrimaryKey(t => t.WalkInPaymentsId);
            
            CreateTable(
                "dbo.WalkInRequests",
                c => new
                    {
                        WalkInRequestId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        DeviceProblemId = c.Int(nullable: false),
                        DeviceDescriptionId = c.Int(nullable: false),
                        StorageId = c.Int(nullable: false),
                        ColourId = c.Int(nullable: false),
                        IMEI = c.String(maxLength: 15),
                        WalkInDate = c.DateTime(nullable: false),
                        WalkInTimesId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        RequestDateTime = c.DateTime(nullable: false),
                        UserId = c.String(),
                        PaymentStatusId = c.Int(nullable: false),
                        ApprovelCharge = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WalkInRequestId)
                .ForeignKey("dbo.Colours", t => t.ColourId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceDescriptions", t => t.DeviceDescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceProblems", t => t.DeviceProblemId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentStatus", t => t.PaymentStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .ForeignKey("dbo.WalkInTimes", t => t.WalkInTimesId, cascadeDelete: true)
                .Index(t => t.DeviceProblemId)
                .Index(t => t.DeviceDescriptionId)
                .Index(t => t.StorageId)
                .Index(t => t.ColourId)
                .Index(t => t.WalkInTimesId)
                .Index(t => t.PaymentStatusId);
            
            CreateTable(
                "dbo.WalkInTimes",
                c => new
                    {
                        WalkInTimesId = c.Int(nullable: false, identity: true),
                        WalkInTime = c.String(),
                    })
                .PrimaryKey(t => t.WalkInTimesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalkInRequests", "WalkInTimesId", "dbo.WalkInTimes");
            DropForeignKey("dbo.WalkInRequests", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.WalkInRequests", "PaymentStatusId", "dbo.PaymentStatus");
            DropForeignKey("dbo.WalkInRequests", "DeviceProblemId", "dbo.DeviceProblems");
            DropForeignKey("dbo.WalkInRequests", "DeviceDescriptionId", "dbo.DeviceDescriptions");
            DropForeignKey("dbo.WalkInRequests", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SupplierParts", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierParts", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Requests", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.Requests", "PaymentStatusId", "dbo.PaymentStatus");
            DropForeignKey("dbo.Requests", "DeviceProblemId", "dbo.DeviceProblems");
            DropForeignKey("dbo.Requests", "DeviceDescriptionId", "dbo.DeviceDescriptions");
            DropForeignKey("dbo.Requests", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.DeviceStatusWalkIns", "RepairStatusId", "dbo.RepairStatus");
            DropForeignKey("dbo.DeviceStatus", "RepairStatusId", "dbo.RepairStatus");
            DropForeignKey("dbo.DeviceDescriptions", "BrandId", "dbo.Brands");
            DropIndex("dbo.WalkInRequests", new[] { "PaymentStatusId" });
            DropIndex("dbo.WalkInRequests", new[] { "WalkInTimesId" });
            DropIndex("dbo.WalkInRequests", new[] { "ColourId" });
            DropIndex("dbo.WalkInRequests", new[] { "StorageId" });
            DropIndex("dbo.WalkInRequests", new[] { "DeviceDescriptionId" });
            DropIndex("dbo.WalkInRequests", new[] { "DeviceProblemId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SupplierParts", new[] { "SupplierId" });
            DropIndex("dbo.SupplierParts", new[] { "PartsId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Requests", new[] { "PaymentStatusId" });
            DropIndex("dbo.Requests", new[] { "ColourId" });
            DropIndex("dbo.Requests", new[] { "StorageId" });
            DropIndex("dbo.Requests", new[] { "DeviceDescriptionId" });
            DropIndex("dbo.Requests", new[] { "DeviceProblemId" });
            DropIndex("dbo.DeviceStatusWalkIns", new[] { "RepairStatusId" });
            DropIndex("dbo.DeviceStatus", new[] { "RepairStatusId" });
            DropIndex("dbo.DeviceDescriptions", new[] { "BrandId" });
            DropTable("dbo.WalkInTimes");
            DropTable("dbo.WalkInRequests");
            DropTable("dbo.WalkInPayments");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplierParts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Storages");
            DropTable("dbo.Requests");
            DropTable("dbo.RequestPayments");
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.Parts");
            DropTable("dbo.Employees");
            DropTable("dbo.DeviceStatusWalkIns");
            DropTable("dbo.RepairStatus");
            DropTable("dbo.DeviceStatus");
            DropTable("dbo.DeviceProblems");
            DropTable("dbo.DeviceDescriptions");
            DropTable("dbo.Colours");
            DropTable("dbo.Brands");
        }
    }
}
