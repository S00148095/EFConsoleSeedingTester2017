namespace EFConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseandstudentsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        CourseYear = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourse", "StudentID", "dbo.Student");
            DropForeignKey("dbo.StudentCourse", "CourseID", "dbo.Course");
            DropIndex("dbo.StudentCourse", new[] { "CourseID" });
            DropIndex("dbo.StudentCourse", new[] { "StudentID" });
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Course");
        }
    }
}
