namespace SignupPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectsEntities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        field = c.String(),
                        dateofcreation = c.String(),
                        deadline = c.String(),
                        teacher_id = c.String(),
                        progress = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TeacherEntities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstname = c.String(nullable: false),
                        lastname = c.String(nullable: false),
                        designation = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 60),
                        phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeacherEntities");
            DropTable("dbo.ProjectsEntities");
        }
    }
}
