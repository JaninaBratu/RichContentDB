namespace RCD.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_file : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFile",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FileID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblFile");
        }
    }
}
