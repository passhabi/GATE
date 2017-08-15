namespace GATE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tests", "LastUpdate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "LastUpdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
