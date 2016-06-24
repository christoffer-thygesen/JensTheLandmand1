namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class links : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Links", "LinkURL", c => c.String(nullable: false));
            AlterColumn("dbo.Links", "LinkDesc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Links", "LinkDesc", c => c.String());
            AlterColumn("dbo.Links", "LinkURL", c => c.String());
        }
    }
}
