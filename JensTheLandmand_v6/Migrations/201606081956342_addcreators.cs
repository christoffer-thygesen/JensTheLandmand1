namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcreators : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Creator", c => c.String());
            AddColumn("dbo.Topics", "Creator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topics", "Creator");
            DropColumn("dbo.Comments", "Creator");
        }
    }
}
