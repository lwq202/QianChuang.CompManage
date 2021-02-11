using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QianChuang.CompManage.DataAccess.Migrations
{
    public partial class UserInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrgId",
                table: "FrameworkUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "FrameworkUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FrameworkOrg",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOrgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManageUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinkMan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgType = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkOrg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkOrg_FrameworkUsers_ManageUserId",
                        column: x => x.ManageUserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FrameworkTeam",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    OrgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkTeam", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkTeam_FrameworkOrg_OrgId",
                        column: x => x.OrgId,
                        principalTable: "FrameworkOrg",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameworkTeam_FrameworkUsers_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_OrgId",
                table: "FrameworkUsers",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_TeamId",
                table: "FrameworkUsers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkOrg_ManageUserId",
                table: "FrameworkOrg",
                column: "ManageUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkTeam_LeaderId",
                table: "FrameworkTeam",
                column: "LeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkTeam_OrgId",
                table: "FrameworkTeam",
                column: "OrgId");

            migrationBuilder.AddForeignKey(
                name: "FK_FrameworkUsers_FrameworkOrg_OrgId",
                table: "FrameworkUsers",
                column: "OrgId",
                principalTable: "FrameworkOrg",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FrameworkUsers_FrameworkTeam_TeamId",
                table: "FrameworkUsers",
                column: "TeamId",
                principalTable: "FrameworkTeam",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FrameworkUsers_FrameworkOrg_OrgId",
                table: "FrameworkUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FrameworkUsers_FrameworkTeam_TeamId",
                table: "FrameworkUsers");

            migrationBuilder.DropTable(
                name: "FrameworkTeam");

            migrationBuilder.DropTable(
                name: "FrameworkOrg");

            migrationBuilder.DropIndex(
                name: "IX_FrameworkUsers_OrgId",
                table: "FrameworkUsers");

            migrationBuilder.DropIndex(
                name: "IX_FrameworkUsers_TeamId",
                table: "FrameworkUsers");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "FrameworkUsers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "FrameworkUsers");
        }
    }
}
