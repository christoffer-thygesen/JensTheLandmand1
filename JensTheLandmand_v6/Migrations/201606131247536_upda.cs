namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upda : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Comment", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Comment", c => c.String());
        }
    }
}
