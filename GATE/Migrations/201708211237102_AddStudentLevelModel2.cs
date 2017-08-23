namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentLevelModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentLevels", "Level_Id", "dbo.Levels");
            DropForeignKey("dbo.StudentLevels", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentLevels", new[] { "Level_Id" });
            DropIndex("dbo.StudentLevels", new[] { "Student_Id" });
            RenameColumn(table: "dbo.StudentLevels", name: "Level_Id", newName: "LevelId");
            RenameColumn(table: "dbo.StudentLevels", name: "Student_Id", newName: "StudentId");
            AlterColumn("dbo.StudentLevels", "LevelId", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentLevels", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentLevels", "StudentId");
            CreateIndex("dbo.StudentLevels", "LevelId");
            AddForeignKey("dbo.StudentLevels", "LevelId", "dbo.Levels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentLevels", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.StudentLevels", "StudentsId");
            DropColumn("dbo.StudentLevels", "LevelsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentLevels", "LevelsId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentLevels", "StudentsId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentLevels", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentLevels", "LevelId", "dbo.Levels");
            DropIndex("dbo.StudentLevels", new[] { "LevelId" });
            DropIndex("dbo.StudentLevels", new[] { "StudentId" });
            AlterColumn("dbo.StudentLevels", "StudentId", c => c.Int());
            AlterColumn("dbo.StudentLevels", "LevelId", c => c.Int());
            RenameColumn(table: "dbo.StudentLevels", name: "StudentId", newName: "Student_Id");
            RenameColumn(table: "dbo.StudentLevels", name: "LevelId", newName: "Level_Id");
            CreateIndex("dbo.StudentLevels", "Student_Id");
            CreateIndex("dbo.StudentLevels", "Level_Id");
            AddForeignKey("dbo.StudentLevels", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.StudentLevels", "Level_Id", "dbo.Levels", "Id");
        }
    }
}
