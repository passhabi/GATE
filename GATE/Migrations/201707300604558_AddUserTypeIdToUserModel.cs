namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTypeIdToUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserTypeId");
        }
    }
}
