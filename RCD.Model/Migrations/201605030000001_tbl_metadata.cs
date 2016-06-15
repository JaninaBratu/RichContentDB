namespace RCD.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_metadata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblMetadata",
                c => new
                    {
                        MetadataID = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        FileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MetadataID)
                .ForeignKey("dbo.tblFile", t => t.FileID, cascadeDelete: true)
                .Index(t => t.FileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMetadata", "FileID", "dbo.tblFile");
            DropIndex("dbo.tblMetadata", new[] { "FileID" });
            DropTable("dbo.tblMetadata");
        }
    }
}
