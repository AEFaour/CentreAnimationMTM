namespace WebApplicationAuthManyToManyTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAbonne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abonnes", "Prenom", c => c.String());
            AlterColumn("dbo.Abonnes", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abonnes", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Abonnes", "Prenom", c => c.String(nullable: false));
        }
    }
}
