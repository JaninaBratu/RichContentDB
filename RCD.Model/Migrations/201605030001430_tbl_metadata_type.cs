namespace RCD.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_metadata_type : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblMetadataType",
                c => new
                    {
                        MetadataTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MetadataTypeID);
            
            AddColumn("dbo.tblMetadata", "MetadataTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.tblMetadata", "MetadataTypeID");
            AddForeignKey("dbo.tblMetadata", "MetadataTypeID", "dbo.tblMetadataType", "MetadataTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMetadata", "MetadataTypeID", "dbo.tblMetadataType");
            DropIndex("dbo.tblMetadata", new[] { "MetadataTypeID" });
            DropColumn("dbo.tblMetadata", "MetadataTypeID");
            DropTable("dbo.tblMetadataType");
        }
    }
}
