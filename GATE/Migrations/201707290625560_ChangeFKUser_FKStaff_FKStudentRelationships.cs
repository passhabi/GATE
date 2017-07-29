namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFKUser_FKStaff_FKStudentRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "Id", "dbo.Users");
            DropForeignKey("dbo.Students", "Id", "dbo.Users");
            DropForeignKey("dbo.Payments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentTests", "StudentId", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Staffs", new[] { "Id" });
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Staffs");
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Staffs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "Id");
            AddPrimaryKey("dbo.Staffs", "Id");
            CreateIndex("dbo.Users", "StudentId");
            CreateIndex("dbo.Users", "StaffId");
            AddForeignKey("dbo.Users", "StaffId", "dbo.Staffs", "Id");
            AddForeignKey("dbo.Users", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.Payments", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentTests", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "UserId");
            DropColumn("dbo.Staffs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentTests", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Payments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Users", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Users", "StaffId", "dbo.Staffs");
            DropIndex("dbo.Users", new[] { "StaffId" });
            DropIndex("dbo.Users", new[] { "StudentId" });
            DropPrimaryKey("dbo.Staffs");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Staffs", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Staffs", "Id");
            AddPrimaryKey("dbo.Students", "Id");
            CreateIndex("dbo.Staffs", "Id");
            CreateIndex("dbo.Students", "Id");
            AddForeignKey("dbo.StudentTests", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Staffs", "Id", "dbo.Users", "Id");
        }
    }
}
