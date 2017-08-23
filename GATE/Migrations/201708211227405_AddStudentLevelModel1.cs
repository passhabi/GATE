namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentLevelModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentsId = c.Int(nullable: false),
                        LevelsId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Level_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Levels", t => t.Level_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Level_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentLevels", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentLevels", "Level_Id", "dbo.Levels");
            DropIndex("dbo.StudentLevels", new[] { "Student_Id" });
            DropIndex("dbo.StudentLevels", new[] { "Level_Id" });
            DropTable("dbo.StudentLevels");
        }
    }
}
