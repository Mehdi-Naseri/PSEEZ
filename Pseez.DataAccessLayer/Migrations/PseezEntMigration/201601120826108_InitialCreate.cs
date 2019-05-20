namespace Pseez.DataAccessLayer.Migrations.PseezEntMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "[IT.DataCenter].Backup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemName = c.String(nullable: false),
                        IP = c.String(),
                        FullBackupAddress = c.String(),
                        DifferentialBackupAddress = c.String(),
                        IncrementalBackupAddress = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "[Common.Contact].ContactGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                        ContactListId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("[Common.Contact].ContactList", t => t.ContactListId, cascadeDelete: true)
                .Index(t => new { t.Name, t.ContactListId }, unique: true, name: "IX_NameAndContactList");
            
            CreateTable(
                "[Common.Contact].ContactList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Identity.AspNetUsers",
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
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "Identity.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Identity.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Identity.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Identity.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "[Common.Contact].Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Tell = c.String(nullable: false, maxLength: 30),
                        Comment = c.String(),
                        ContactGroupId = c.Int(nullable: false),
                        ContactListId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("[Common.Contact].ContactGroup", t => t.ContactGroupId, cascadeDelete: true)
                .ForeignKey("[Common.Contact].ContactList", t => t.ContactListId)
                .Index(t => t.Tell, unique: true)
                .Index(t => t.ContactGroupId)
                .Index(t => t.ContactListId);
            
            CreateTable(
                "[Common.Contact].UserContactList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 60),
                        ContactListId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("[Common.Contact].ContactList", t => t.ContactListId, cascadeDelete: true)
                .Index(t => new { t.UserId, t.ContactListId }, unique: true, name: "IX_UserAndContactList");
            
            CreateTable(
                "[Common.Contact].UserDefaultContactList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ContactListId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("[Common.Contact].ContactList", t => t.ContactListId, cascadeDelete: true)
                .Index(t => t.ContactListId);
            
            CreateTable(
                "[Pmbok.Management].Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Title = c.String(nullable: false, maxLength: 500),
                        Message = c.String(nullable: false, maxLength: 500),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "[Pmbok.ProjectDocuments].ProjectDocumentFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        File = c.Binary(nullable: false),
                        UploadDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(nullable: false),
                        ProjectDocumentId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("[Pmbok.Projects].Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("[Pmbok.ProjectDocuments].ProjectDocument", t => t.ProjectDocumentId, cascadeDelete: true)
                .Index(t => t.ProjectDocumentId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "[Pmbok.Projects].Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(storeType: "date"),
                        EndDate = c.DateTime(storeType: "date"),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "[Pmbok.ProjectDocuments].ProjectDocument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(nullable: false, maxLength: 50),
                        DocumentType = c.String(nullable: false, maxLength: 50),
                        ParentDocumentName = c.String(maxLength: 50),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "[Pmbok.ProjectDocuments].ProjectDocumentFileDeleted",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        File = c.Binary(nullable: false),
                        UploadDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(nullable: false),
                        ProjectDocumentId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("[Pmbok.Projects].Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("[Pmbok.ProjectDocuments].ProjectDocument", t => t.ProjectDocumentId, cascadeDelete: true)
                .Index(t => t.ProjectDocumentId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "[Pmbok.ProjectDocuments].ProjectDocumentValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(nullable: false),
                        ProjectDocumentId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("[Pmbok.Projects].Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("[Pmbok.ProjectDocuments].ProjectDocument", t => t.ProjectDocumentId, cascadeDelete: true)
                .Index(t => t.ProjectDocumentId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "VisitRegistration.Registration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        IPECUsername = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        TelephoneNumber = c.String(nullable: false, maxLength: 50),
                        Mobile = c.String(nullable: false, maxLength: 50),
                        FaxNumber = c.String(),
                        Address = c.String(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CompanyPhone = c.String(nullable: false, maxLength: 50),
                        CompanyAddress = c.String(nullable: false),
                        RegistrationDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Identity.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "[IT.DataCenter].Server",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServerName = c.String(nullable: false, maxLength: 30),
                        IP = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ServerName, unique: true);
            
            CreateTable(
                "[Common.Management].WebsiteVisitor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HostAddress = c.String(nullable: false),
                        HostName = c.String(nullable: false),
                        Browser = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        UrlReferrer = c.String(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Identity.AspNetUserRoles", "RoleId", "Identity.AspNetRoles");
            DropForeignKey("[Pmbok.ProjectDocuments].ProjectDocumentValue", "ProjectDocumentId", "[Pmbok.ProjectDocuments].ProjectDocument");
            DropForeignKey("[Pmbok.ProjectDocuments].ProjectDocumentValue", "ProjectId", "[Pmbok.Projects].Project");
            DropForeignKey("[Pmbok.ProjectDocuments].ProjectDocumentFileDeleted", "ProjectDocumentId", "[Pmbok.ProjectDocuments].ProjectDocument");
            DropForeignKey("[Pmbok.ProjectDocuments].ProjectDocumentFileDeleted", "ProjectId", "[Pmbok.Projects].Project");
            DropForeignKey("[Pmbok.ProjectDocuments].ProjectDocumentFile", "ProjectDocumentId", "[Pmbok.ProjectDocuments].ProjectDocument");
            DropForeignKey("[Pmbok.ProjectDocuments].ProjectDocumentFile", "ProjectId", "[Pmbok.Projects].Project");
            DropForeignKey("[Common.Contact].ContactGroup", "ContactListId", "[Common.Contact].ContactList");
            DropForeignKey("[Common.Contact].UserDefaultContactList", "ContactListId", "[Common.Contact].ContactList");
            DropForeignKey("[Common.Contact].UserContactList", "ContactListId", "[Common.Contact].ContactList");
            DropForeignKey("[Common.Contact].Contact", "ContactListId", "[Common.Contact].ContactList");
            DropForeignKey("[Common.Contact].Contact", "ContactGroupId", "[Common.Contact].ContactGroup");
            DropForeignKey("[Common.Contact].ContactList", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserRoles", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserLogins", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserClaims", "UserId", "Identity.AspNetUsers");
            DropIndex("[IT.DataCenter].Server", new[] { "ServerName" });
            DropIndex("Identity.AspNetRoles", "RoleNameIndex");
            DropIndex("[Pmbok.ProjectDocuments].ProjectDocumentValue", new[] { "ProjectId" });
            DropIndex("[Pmbok.ProjectDocuments].ProjectDocumentValue", new[] { "ProjectDocumentId" });
            DropIndex("[Pmbok.ProjectDocuments].ProjectDocumentFileDeleted", new[] { "ProjectId" });
            DropIndex("[Pmbok.ProjectDocuments].ProjectDocumentFileDeleted", new[] { "ProjectDocumentId" });
            DropIndex("[Pmbok.Projects].Project", new[] { "Name" });
            DropIndex("[Pmbok.ProjectDocuments].ProjectDocumentFile", new[] { "ProjectId" });
            DropIndex("[Pmbok.ProjectDocuments].ProjectDocumentFile", new[] { "ProjectDocumentId" });
            DropIndex("[Common.Contact].UserDefaultContactList", new[] { "ContactListId" });
            DropIndex("[Common.Contact].UserContactList", "IX_UserAndContactList");
            DropIndex("[Common.Contact].Contact", new[] { "ContactListId" });
            DropIndex("[Common.Contact].Contact", new[] { "ContactGroupId" });
            DropIndex("[Common.Contact].Contact", new[] { "Tell" });
            DropIndex("Identity.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("Identity.AspNetUserRoles", new[] { "UserId" });
            DropIndex("Identity.AspNetUserLogins", new[] { "UserId" });
            DropIndex("Identity.AspNetUserClaims", new[] { "UserId" });
            DropIndex("Identity.AspNetUsers", "UserNameIndex");
            DropIndex("[Common.Contact].ContactList", new[] { "UserId" });
            DropIndex("[Common.Contact].ContactList", new[] { "Name" });
            DropIndex("[Common.Contact].ContactGroup", "IX_NameAndContactList");
            DropTable("[Common.Management].WebsiteVisitor");
            DropTable("[IT.DataCenter].Server");
            DropTable("Identity.AspNetRoles");
            DropTable("VisitRegistration.Registration");
            DropTable("[Pmbok.ProjectDocuments].ProjectDocumentValue");
            DropTable("[Pmbok.ProjectDocuments].ProjectDocumentFileDeleted");
            DropTable("[Pmbok.ProjectDocuments].ProjectDocument");
            DropTable("[Pmbok.Projects].Project");
            DropTable("[Pmbok.ProjectDocuments].ProjectDocumentFile");
            DropTable("[Pmbok.Management].Log");
            DropTable("[Common.Contact].UserDefaultContactList");
            DropTable("[Common.Contact].UserContactList");
            DropTable("[Common.Contact].Contact");
            DropTable("Identity.AspNetUserRoles");
            DropTable("Identity.AspNetUserLogins");
            DropTable("Identity.AspNetUserClaims");
            DropTable("Identity.AspNetUsers");
            DropTable("[Common.Contact].ContactList");
            DropTable("[Common.Contact].ContactGroup");
            DropTable("[IT.DataCenter].Backup");
        }
    }
}
