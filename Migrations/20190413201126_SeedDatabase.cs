using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Makes (Name) values ('Make1')");
            migrationBuilder.Sql("insert into Makes (Name) values ('Make2')");
            migrationBuilder.Sql("insert into Makes (Name) values ('Make3')");

            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make1-ModelA', (SELECT ID FROM Makes where Name='Make1'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make1-ModelB', (SELECT ID FROM Makes where Name='Make1'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make1-ModelC', (SELECT ID FROM Makes where Name='Make1'))");

            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make2-ModelA', (SELECT ID FROM Makes where Name='Make2'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make2-ModelB', (SELECT ID FROM Makes where Name='Make2'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make2-ModelC', (SELECT ID FROM Makes where Name='Make2'))");

            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make3-ModelA', (SELECT ID FROM Makes where Name='Make3'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make2-ModelB', (SELECT ID FROM Makes where Name='Make3'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make3-ModelC', (SELECT ID FROM Makes where Name='Make3'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes Where Name in ('Make1', 'Make2', 'Make3')");
        }
    }
}
