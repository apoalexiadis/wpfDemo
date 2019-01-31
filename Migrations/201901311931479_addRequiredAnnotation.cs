namespace WPFUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonModels", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.PersonModels", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonModels", "LastName", c => c.String());
            AlterColumn("dbo.PersonModels", "FirstName", c => c.String());
        }
    }
}
