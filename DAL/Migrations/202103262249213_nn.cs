namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "image", c => c.String());
            AlterColumn("dbo.Courses", "image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "image", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "image", c => c.String(nullable: false));
        }
    }
}
