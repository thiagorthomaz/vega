using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class FixMissspelledModelsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update Models set Name = 'Make3-ModelB' where Name='Make2-ModelB' and MakeId=3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
