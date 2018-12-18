namespace ContactAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_birthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Birthday");
        }
    }
}
