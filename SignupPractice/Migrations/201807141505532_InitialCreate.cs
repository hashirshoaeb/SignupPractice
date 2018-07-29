namespace SignupPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        email = c.String(),
                        password = c.String(),
                        phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Identities");
        }
    }
}
