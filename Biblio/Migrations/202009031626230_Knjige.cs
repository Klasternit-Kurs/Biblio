namespace Biblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Knjige : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Knjigas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Primeraka = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Knjigas");
        }
    }
}
