using Microsoft.EntityFrameworkCore.Migrations;

namespace QianChuang.CompManage.DataAccess.Migrations
{
    public partial class flow1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsFinish",
                table: "FlowInstance",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FrmId",
                table: "FlowInstance",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlowInstance_FrmId",
                table: "FlowInstance",
                column: "FrmId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowInstance_FlowForm_FrmId",
                table: "FlowInstance",
                column: "FrmId",
                principalTable: "FlowForm",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowInstance_FlowForm_FrmId",
                table: "FlowInstance");

            migrationBuilder.DropIndex(
                name: "IX_FlowInstance_FrmId",
                table: "FlowInstance");

            migrationBuilder.AlterColumn<int>(
                name: "IsFinish",
                table: "FlowInstance",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FrmId",
                table: "FlowInstance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
