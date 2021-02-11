using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QianChuang.CompManage.DataAccess.Migrations
{
    public partial class UserInit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FrameworkOrg",
                columns: new[] { "ID", "CreateBy", "CreateTime", "IsValid", "LinkMan", "LinkPhone", "ManageUserId", "OrgName", "OrgType", "SOrgName", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, null, true, "李文哲", "18006847261", null, "乾创财务", 0, "浙江乾创财务有限公司", null, null },
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, null, true, "客户", null, null, "客户", 0, "客户", null, null }
                });

            migrationBuilder.InsertData(
                table: "FrameworkRoles",
                columns: new[] { "ID", "CreateBy", "CreateTime", "RoleCode", "RoleName", "RoleRemark", "TenantCode", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "初始化数据", null, "011", "总经理", null, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "初始化数据", null, "012", "财务", null, null, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "初始化数据", null, "013", "销售主管", null, null, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "初始化数据", null, "014", "销售", null, null, null, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "初始化数据", null, "015", "支撑", null, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FrameworkOrg",
                keyColumn: "ID",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "FrameworkOrg",
                keyColumn: "ID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "FrameworkRoles",
                keyColumn: "ID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));
        }
    }
}
