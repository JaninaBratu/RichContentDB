namespace RCD.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_setting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblSetting",
                c => new
                    {
                        SettingID = c.Int(nullable: false, identity: true),
                        PeriodTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SettingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblSetting");
        }
    }
}
