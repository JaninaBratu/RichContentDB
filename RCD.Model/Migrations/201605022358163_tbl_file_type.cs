namespace RCD.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_file_type : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFileType",
                c => new
                    {
                        FileTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FileTypeID);
            
            AddColumn("dbo.tblFile", "FileTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.tblFile", "FileTypeID");
            AddForeignKey("dbo.tblFile", "FileTypeID", "dbo.tblFileType", "FileTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFile", "FileTypeID", "dbo.tblFileType");
            DropIndex("dbo.tblFile", new[] { "FileTypeID" });
            DropColumn("dbo.tblFile", "FileTypeID");
            DropTable("dbo.tblFileType");
        }
    }
}
