namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hvad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topics", "TopicTitle", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Topics", "TopicNote", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topics", "TopicNote", c => c.String());
            AlterColumn("dbo.Topics", "TopicTitle", c => c.String(maxLength: 128));
        }
    }
}
