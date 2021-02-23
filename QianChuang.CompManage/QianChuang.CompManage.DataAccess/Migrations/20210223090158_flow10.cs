using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QianChuang.CompManage.DataAccess.Migrations
{
    public partial class flow10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowInstanceOperationHistory");

            migrationBuilder.DropTable(
                name: "FlowInstanceTransitionHistory");

            migrationBuilder.DropTable(
                name: "FlowInstance");

            migrationBuilder.DropTable(
                name: "FlowForm");

            migrationBuilder.DropTable(
                name: "FlowScheme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowForm",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentParse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DbName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteMark = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields = table.Column<int>(type: "int", nullable: false),
                    FrmType = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowForm", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlowScheme",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthorizeType = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteMark = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmType = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeCanUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowScheme", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlowInstance",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActivityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityType = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowLevel = table.Column<int>(type: "int", nullable: false),
                    FrmContentData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmContentParse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FrmType = table.Column<int>(type: "int", nullable: false),
                    IsFinish = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    MakerList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SchemeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowInstance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FlowInstance_FlowForm_FrmId",
                        column: x => x.FrmId,
                        principalTable: "FlowForm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlowInstance_FlowScheme_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "FlowScheme",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowInstanceOperationHistory",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstanceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowInstanceOperationHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FlowInstanceOperationHistory_FlowInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "FlowInstance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlowInstanceTransitionHistory",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromNodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromNodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromNodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstanceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsFinish = table.Column<bool>(type: "bit", nullable: false),
                    ToNodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToNodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToNodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransitionState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowInstanceTransitionHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FlowInstanceTransitionHistory_FlowInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "FlowInstance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowInstance_FrmId",
                table: "FlowInstance",
                column: "FrmId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowInstance_SchemeId",
                table: "FlowInstance",
                column: "SchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowInstanceOperationHistory_InstanceId",
                table: "FlowInstanceOperationHistory",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowInstanceTransitionHistory_InstanceId",
                table: "FlowInstanceTransitionHistory",
                column: "InstanceId");
        }
    }
}
