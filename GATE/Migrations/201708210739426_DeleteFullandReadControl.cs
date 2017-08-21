namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFullandReadControl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Staffs", "ReadControl");
            DropColumn("dbo.Staffs", "FullControl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "FullControl", c => c.Boolean(nullable: false));
            AddColumn("dbo.Staffs", "ReadControl", c => c.Boolean(nullable: false));
        }
    }
}
