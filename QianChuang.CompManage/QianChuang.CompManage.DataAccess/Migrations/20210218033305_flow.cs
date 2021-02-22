using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QianChuang.CompManage.DataAccess.Migrations
{
    public partial class flow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "FrameworkUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlowForm",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmType = table.Column<int>(type: "int", nullable: false),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields = table.Column<int>(type: "int", nullable: false),
                    ContentData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentParse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<int>(type: "int", nullable: false),
                    DeleteMark = table.Column<int>(type: "int", nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
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
                    SchemeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeCanUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmType = table.Column<int>(type: "int", nullable: false),
                    AuthorizeType = table.Column<int>(type: "int", nullable: false),
                    SortCode = table.Column<int>(type: "int", nullable: false),
                    DeleteMark = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
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
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityType = table.Column<int>(type: "int", nullable: true),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmType = table.Column<int>(type: "int", nullable: false),
                    FrmContentData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmContentParse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrmId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowLevel = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFinish = table.Column<int>(type: "int", nullable: false),
                    MakerList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowInstance", x => x.ID);
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
                    InstanceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    InstanceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FromNodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromNodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromNodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToNodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToNodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToNodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransitionState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFinish = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.UpdateData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "RoleName",
                value: "设立执行人");

            migrationBuilder.InsertData(
                table: "FrameworkRoles",
                columns: new[] { "ID", "CreateBy", "CreateTime", "RoleCode", "RoleName", "RoleRemark", "TenantCode", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), "初始化数据", null, "016", "客户", null, null, null, null },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "初始化数据", null, "017", "代理商", null, null, null, null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "初始化数据", null, "018", "主办会计", null, null, null, null }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowForm");

            migrationBuilder.DropTable(
                name: "FlowInstanceOperationHistory");

            migrationBuilder.DropTable(
                name: "FlowInstanceTransitionHistory");

            migrationBuilder.DropTable(
                name: "FlowInstance");

            migrationBuilder.DropTable(
                name: "FlowScheme");

            migrationBuilder.DeleteData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "FrameworkUsers");

            migrationBuilder.UpdateData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "RoleName",
                value: "支撑");
        }
    }
}
