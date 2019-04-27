namespace SuperHero.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "alterEgoName", c => c.String());
            AddColumn("dbo.Heroes", "primaryAbility", c => c.String());
            AddColumn("dbo.Heroes", "secondaryAbility", c => c.String());
            AddColumn("dbo.Heroes", "catchphrase", c => c.String());
            AddColumn("dbo.Heroes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "Discriminator");
            DropColumn("dbo.Heroes", "catchphrase");
            DropColumn("dbo.Heroes", "secondaryAbility");
            DropColumn("dbo.Heroes", "primaryAbility");
            DropColumn("dbo.Heroes", "alterEgoName");
        }
    }
}
