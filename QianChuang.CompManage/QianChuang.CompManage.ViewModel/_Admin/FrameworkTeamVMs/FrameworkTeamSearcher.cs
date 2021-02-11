using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkTeamVMs
{
    public partial class FrameworkTeamSearcher : BaseSearcher
    {
        [Display(Name = " 团队名")]
        public String Name { get; set; }
        [Display(Name = "领导者")]
        public Guid? LeaderId { get; set; }
        [Display(Name = "团队等级")]
        public TeamLevel? Level { get; set; }
        [Display(Name = "组织")]
        public Guid? OrgId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
