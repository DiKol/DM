namespace DM.Migrations.User
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Birth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Birth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Birth", c => c.DateTime(nullable: false));
        }
    }
}
