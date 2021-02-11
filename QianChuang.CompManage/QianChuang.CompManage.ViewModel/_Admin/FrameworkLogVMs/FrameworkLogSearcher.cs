using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkLogVMs
{
    public partial class FrameworkLogSearcher : BaseSearcher
    {
        [Display(Name = "消息")]
        public String Message { get; set; }
        [Display(Name = "等级")]
        public String Level { get; set; }
        [Display(Name = "时间")]
        public DateRange TimeStamp { get; set; }

        protected override void InitVM()
        {
        }

    }
}
