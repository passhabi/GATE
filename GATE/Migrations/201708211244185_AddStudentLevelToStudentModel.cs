namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentLevelToStudentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentLevels", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.StudentLevels", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentLevels", new[] { "StudentId" });
            DropIndex("dbo.StudentLevels", new[] { "LevelId" });
            AddColumn("dbo.Students", "LevelId", c => c.Int());
            CreateIndex("dbo.Students", "LevelId");
            AddForeignKey("dbo.Students", "LevelId", "dbo.Levels", "Id");
            DropColumn("dbo.StudentCourses", "LastUpdate");
            DropTable("dbo.StudentLevels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentCourses", "LastUpdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropForeignKey("dbo.Students", "LevelId", "dbo.Levels");
            DropIndex("dbo.Students", new[] { "LevelId" });
            DropColumn("dbo.Students", "LevelId");
            CreateIndex("dbo.StudentLevels", "LevelId");
            CreateIndex("dbo.StudentLevels", "StudentId");
            AddForeignKey("dbo.StudentLevels", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentLevels", "LevelId", "dbo.Levels", "Id", cascadeDelete: true);
        }
    }
}
