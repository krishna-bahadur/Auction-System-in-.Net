namespace AuctionSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuctionId = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pictures", t => t.PictureId, cascadeDelete: true)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .Index(t => t.AuctionId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Auctions", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "Image", c => c.String());
            DropForeignKey("dbo.AuctionPictures", "AuctionId", "dbo.Auctions");
            DropForeignKey("dbo.AuctionPictures", "PictureId", "dbo.Pictures");
            DropIndex("dbo.AuctionPictures", new[] { "PictureId" });
            DropIndex("dbo.AuctionPictures", new[] { "AuctionId" });
            DropTable("dbo.Pictures");
            DropTable("dbo.AuctionPictures");
        }
    }
}
