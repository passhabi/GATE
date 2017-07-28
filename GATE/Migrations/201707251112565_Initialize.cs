namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Fee = c.Short(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Short(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingCode = c.String(),
                        Confirmed = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TestId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        NickName = c.String(maxLength: 50),
                        FamilyName = c.String(nullable: false, maxLength: 50),
                        NationalCode = c.Int(nullable: false),
                        FathersName = c.String(maxLength: 50),
                        Birthday = c.DateTime(nullable: false),
                        BornCity = c.String(maxLength: 50),
                        Telephone = c.Int(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Address = c.String(),
                        Plaque = c.Int(nullable: false),
                        StudentNumber = c.String(nullable: false),
                        Gpa = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Paid = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.StudentTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TestId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Fee = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        FamilyName = c.String(nullable: false, maxLength: 50),
                        ReadControl = c.Boolean(nullable: false),
                        FullControl = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CellPhone = c.Int(nullable: false),
                        Confirmed = c.Boolean(nullable: false),
                        UserType = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentTests", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Payments", "TestId", "dbo.Tests");
            DropForeignKey("dbo.StudentTests", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentTests", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Payments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Payments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "LevelId", "dbo.Levels");
            DropIndex("dbo.StudentTests", new[] { "CourseId" });
            DropIndex("dbo.StudentTests", new[] { "TestId" });
            DropIndex("dbo.StudentTests", new[] { "StudentId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.Payments", new[] { "CourseId" });
            DropIndex("dbo.Payments", new[] { "TestId" });
            DropIndex("dbo.Payments", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "LevelId" });
            DropTable("dbo.Users");
            DropTable("dbo.Staffs");
            DropTable("dbo.Tests");
            DropTable("dbo.StudentTests");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Payments");
            DropTable("dbo.Levels");
            DropTable("dbo.Courses");
        }
    }
}
