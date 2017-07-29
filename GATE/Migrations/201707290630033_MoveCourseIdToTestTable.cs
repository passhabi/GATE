namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveCourseIdToTestTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentTests", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentTests", new[] { "CourseId" });
            AddColumn("dbo.Tests", "CourseId", c => c.Int());
            CreateIndex("dbo.Tests", "CourseId");
            AddForeignKey("dbo.Tests", "CourseId", "dbo.Courses", "Id");
            DropColumn("dbo.StudentTests", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentTests", "CourseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tests", "CourseId", "dbo.Courses");
            DropIndex("dbo.Tests", new[] { "CourseId" });
            DropColumn("dbo.Tests", "CourseId");
            CreateIndex("dbo.StudentTests", "CourseId");
            AddForeignKey("dbo.StudentTests", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
