namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Users", "StudentId", "dbo.Students");
            DropIndex("dbo.Users", new[] { "StudentId" });
            DropIndex("dbo.Users", new[] { "StaffId" });
            AlterColumn("dbo.Students", "Telephone", c => c.Int());
            AlterColumn("dbo.Students", "PostalCode", c => c.Int());
            AlterColumn("dbo.Students", "Plaque", c => c.Int());
            AlterColumn("dbo.Students", "StudentNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Gpa", c => c.Int());
            DropColumn("dbo.Users", "StudentId");
            DropColumn("dbo.Users", "StaffId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "StaffId", c => c.Int());
            AddColumn("dbo.Users", "StudentId", c => c.Int());
            AlterColumn("dbo.Students", "Gpa", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "StudentNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Plaque", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "PostalCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Telephone", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "StaffId");
            CreateIndex("dbo.Users", "StudentId");
            AddForeignKey("dbo.Users", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.Users", "StaffId", "dbo.Staffs", "Id");
        }
    }
}
