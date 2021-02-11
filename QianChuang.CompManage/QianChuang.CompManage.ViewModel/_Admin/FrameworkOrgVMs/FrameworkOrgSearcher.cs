using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkOrgVMs
{
    public partial class FrameworkOrgSearcher : BaseSearcher
    {
        [Display(Name = "组织名称")]
        public String OrgName { get; set; }
        [Display(Name = "组织名称简称")]
        public String SOrgName { get; set; }
        [Display(Name = "上级销售")]
        public Guid? ManageUserId { get; set; }
        [Display(Name = "联系人")]
        public String LinkMan { get; set; }
        [Display(Name = "联系电话")]
        public String LinkPhone { get; set; }
        [Display(Name = "组织类型")]
        public OrgTypeEnum? OrgType { get; set; }

        protected override void InitVM()
        {
        }

    }
}
