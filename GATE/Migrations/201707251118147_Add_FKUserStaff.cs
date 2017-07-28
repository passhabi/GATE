namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FKUserStaff : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Staffs");
            AddColumn("dbo.Staffs", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "StaffId", c => c.Int(nullable: false));
            AlterColumn("dbo.Staffs", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Staffs", "Id");
            CreateIndex("dbo.Staffs", "Id");
            AddForeignKey("dbo.Staffs", "Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "Id", "dbo.Users");
            DropIndex("dbo.Staffs", new[] { "Id" });
            DropPrimaryKey("dbo.Staffs");
            AlterColumn("dbo.Staffs", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "StaffId");
            DropColumn("dbo.Staffs", "UserId");
            AddPrimaryKey("dbo.Staffs", "Id");
        }
    }
}
