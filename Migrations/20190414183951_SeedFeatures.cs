using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Features (Name) values ('Features1')");
            migrationBuilder.Sql("insert into Features (Name) values ('Features2')");
            migrationBuilder.Sql("insert into Features (Name) values ('Features3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Features where Name in ('Features1', 'Features2', 'Features3')");
        }
    }
}
