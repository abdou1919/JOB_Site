namespace JOB_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "usersex", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "usersex");
        }
    }
}
