namespace ClimbingStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedguides : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        YrsExp = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.PartyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guides", "PartyId", "dbo.Parties");
            DropIndex("dbo.Guides", new[] { "PartyId" });
            DropTable("dbo.Guides");
        }
    }
}
