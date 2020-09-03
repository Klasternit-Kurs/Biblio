namespace Biblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClanoviBrKnjiga : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clans", "Knjiga", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clans", "Knjiga");
        }
    }
}
