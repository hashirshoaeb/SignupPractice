namespace SignupPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotaions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Identities", "firstname", c => c.String(nullable: false));
            AlterColumn("dbo.Identities", "lastname", c => c.String(nullable: false));
            AlterColumn("dbo.Identities", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Identities", "password", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Identities", "phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Identities", "phone", c => c.Long(nullable: false));
            AlterColumn("dbo.Identities", "password", c => c.String());
            AlterColumn("dbo.Identities", "email", c => c.String());
            AlterColumn("dbo.Identities", "lastname", c => c.String());
            AlterColumn("dbo.Identities", "firstname", c => c.String());
        }
    }
}
