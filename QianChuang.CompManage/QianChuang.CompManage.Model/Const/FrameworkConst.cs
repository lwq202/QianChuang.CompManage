using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QianChuang.CompManage.Model.Const
{
    public static class FrameworkConst
    {
        /// <summary>
        /// 管理组织Id
        /// </summary>
        public static Guid OrgManageId => Guid.Parse("00000000-0000-0000-0000-000000000001");
        /// <summary>
        /// 用户组织Id
        /// </summary>
        public static Guid OrgCustomId => Guid.Parse("11111111-1111-1111-1111-111111111111");

        public static  Guid[] OrgReadOnlyId=> new[]{ OrgManageId, OrgCustomId };
        /// <summary>
        /// 管理员角色1
        /// </summary>
        public static Guid RoleAdminId => Guid.Parse("11111111-1111-1111-1111-111111111111");
        /// <summary>
        /// 财务角色2
        /// </summary>
        public static Guid RoleFinanceId => Guid.Parse("22222222-2222-2222-2222-222222222222");
        /// <summary>
        /// 销售主管角色3
        /// </summary>
        public static Guid RoleSaleManageId => Guid.Parse("33333333-3333-3333-3333-333333333333");
        /// <summary>
        /// 销售角色4
        /// </summary>
        public static Guid RoleSaleId => Guid.Parse("44444444-4444-4444-4444-444444444444");
        /// <summary>
        /// 设立执行人角色5
        /// </summary>
        public static Guid RoleBraceId => Guid.Parse("55555555-5555-5555-5555-555555555555");
        /// <summary>
        /// 客户角色6
        /// </summary>
        public static Guid RoleCustomId => Guid.Parse("66666666-6666-6666-6666-666666666666");
        /// <summary>
        /// 代理商角色7
        /// </summary>
        public static Guid RoleAgentId => Guid.Parse("77777777-7777-7777-7777-777777777777");
        /// <summary>
        /// 主办会计角色8
        /// </summary>
        public static Guid RoleAccountingId => Guid.Parse("88888888-8888-8888-8888-888888888888");
        public static Guid[] RoleReadOnlyId => new[] { RoleAdminId,
            RoleFinanceId, 
            RoleSaleManageId ,
            RoleSaleId ,
            RoleBraceId,
            RoleCustomId,
            RoleAgentId,
            RoleAccountingId
        };
    }
}
