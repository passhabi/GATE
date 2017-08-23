namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aNewChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentDetailsViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetailsViewModels", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentDetailsViewModels", new[] { "Student_Id" });
            DropTable("dbo.StudentDetailsViewModels");
        }
    }
}
