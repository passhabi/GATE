namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullablePropertyToUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CellPhone", c => c.Int());
            AlterColumn("dbo.Users", "LastUpdate", c => c.DateTime());
            AlterColumn("dbo.Users", "StudentId", c => c.Int());
            AlterColumn("dbo.Users", "StaffId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "StaffId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "LastUpdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CellPhone", c => c.Int(nullable: false));
        }
    }
}
