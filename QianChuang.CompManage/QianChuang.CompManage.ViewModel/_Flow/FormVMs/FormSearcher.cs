using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Flow;


namespace QianChuang.CompManage.ViewModel._Flow.FormVMs
{
    public partial class FormSearcher : BaseSearcher
    {
        [Display(Name = "表单名称")]
        public String Name { get; set; }
        [Display(Name = "表单类型，0：默认动态表单；1：Web自定义表单")]
        public FrmTypeEnum? FrmType { get; set; }
        [Display(Name = "字段个数")]
        public Int32? Fields { get; set; }

        protected override void InitVM()
        {
        }

    }
}
