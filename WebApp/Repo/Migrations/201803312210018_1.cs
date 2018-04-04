namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdModel", "Image", c => c.String());
            DropColumn("dbo.AdModel", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdModel", "ImagePath", c => c.String());
            DropColumn("dbo.AdModel", "Image");
        }
    }
}
