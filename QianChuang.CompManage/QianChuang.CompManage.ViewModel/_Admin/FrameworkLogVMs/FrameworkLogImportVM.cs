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
    public partial class FrameworkLogTemplateVM : BaseTemplateVM
    {
        [Display(Name = "消息")]
        public ExcelPropety Message_Excel = ExcelPropety.CreateProperty<FrameworkLog>(x => x.Message);
        [Display(Name = "消息模板")]
        public ExcelPropety MessageTemplate_Excel = ExcelPropety.CreateProperty<FrameworkLog>(x => x.MessageTemplate);
        [Display(Name = "等级")]
        public ExcelPropety Level_Excel = ExcelPropety.CreateProperty<FrameworkLog>(x => x.Level);
        [Display(Name = "时间")]
        public ExcelPropety TimeStamp_Excel = ExcelPropety.CreateProperty<FrameworkLog>(x => x.TimeStamp);
        [Display(Name = "错误明显")]
        public ExcelPropety Exception_Excel = ExcelPropety.CreateProperty<FrameworkLog>(x => x.Exception);
        [Display(Name = "属性")]
        public ExcelPropety Properties_Excel = ExcelPropety.CreateProperty<FrameworkLog>(x => x.Properties);
        [Display(Name = "日志事件")]
        public ExcelPropety LogEvent_Excel = ExcelPropety.CreateProperty<FrameworkLog>(x => x.LogEvent);

	    protected override void InitVM()
        {
        }

    }

    public class FrameworkLogImportVM : BaseImportVM<FrameworkLogTemplateVM, FrameworkLog>
    {

    }

}
