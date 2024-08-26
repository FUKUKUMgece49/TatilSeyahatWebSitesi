namespace TravelTripProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogImage", c => c.String());
            DropColumn("dbo.Blogs", "BlogImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogImage", c => c.String());
            DropColumn("dbo.Blogs", "BlogImage");
        }
    }
}
