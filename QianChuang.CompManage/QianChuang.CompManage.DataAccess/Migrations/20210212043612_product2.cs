using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QianChuang.CompManage.DataAccess.Migrations
{
    public partial class product2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ProductAreaInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "ProductAreaInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProductAreaInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAreaInfos_ImageId",
                table: "ProductAreaInfos",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAreaInfos_FileAttachments_ImageId",
                table: "ProductAreaInfos",
                column: "ImageId",
                principalTable: "FileAttachments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAreaInfos_FileAttachments_ImageId",
                table: "ProductAreaInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProductAreaInfos_ImageId",
                table: "ProductAreaInfos");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ProductAreaInfos");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductAreaInfos");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProductAreaInfos");
        }
    }
}
