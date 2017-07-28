namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FKUserStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentTests", "StudentId", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Students", "Id");
            CreateIndex("dbo.Students", "Id");
            AddForeignKey("dbo.Students", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Payments", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentTests", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentTests", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Payments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "Id", "dbo.Users");
            DropIndex("dbo.Students", new[] { "Id" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "StudentId");
            DropColumn("dbo.Students", "UserId");
            AddPrimaryKey("dbo.Students", "Id");
            AddForeignKey("dbo.StudentTests", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
