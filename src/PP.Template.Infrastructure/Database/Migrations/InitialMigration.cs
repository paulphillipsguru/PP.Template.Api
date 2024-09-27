using FluentMigrator;

namespace PP.Template.Infrastructure.Database.Migrations
{
    [Migration(1, "BaseLine")]
    //TO DO: Remove, only a demo!
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Example")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Example");
        }
    }
}
