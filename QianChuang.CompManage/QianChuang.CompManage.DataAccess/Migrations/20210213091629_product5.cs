using Microsoft.EntityFrameworkCore.Migrations;

namespace QianChuang.CompManage.DataAccess.Migrations
{
    public partial class product5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasProduct",
                table: "ProductAreaInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasProduct",
                table: "ProductAreaInfos");
        }
    }
}
