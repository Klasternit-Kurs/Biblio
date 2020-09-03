namespace Biblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uzeo = c.DateTime(nullable: false),
                        Vratio = c.DateTime(),
                        Zadrzavanje = c.Int(nullable: false),
                        Clan_Id = c.Int(),
                        Knjiga_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clans", t => t.Clan_Id)
                .ForeignKey("dbo.Knjigas", t => t.Knjiga_Id)
                .Index(t => t.Clan_Id)
                .Index(t => t.Knjiga_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Knjiga_Id", "dbo.Knjigas");
            DropForeignKey("dbo.Rents", "Clan_Id", "dbo.Clans");
            DropIndex("dbo.Rents", new[] { "Knjiga_Id" });
            DropIndex("dbo.Rents", new[] { "Clan_Id" });
            DropTable("dbo.Rents");
        }
    }
}
