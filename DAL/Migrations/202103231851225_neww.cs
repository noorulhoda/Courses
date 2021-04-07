namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neww : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "gender", c => c.String());
            AddColumn("dbo.Teachers", "age", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "gender");
            DropColumn("dbo.Teachers", "age");
            DropColumn("dbo.Students", "gender");
        }
    }
}
