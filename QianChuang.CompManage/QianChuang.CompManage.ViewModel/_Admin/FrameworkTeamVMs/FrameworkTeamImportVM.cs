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
    public partial class FrameworkTeamTemplateVM : BaseTemplateVM
    {
        [Display(Name = " 团队名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<FrameworkTeam>(x => x.Name);
        [Display(Name = "领导者")]
        public ExcelPropety Leader_Excel = ExcelPropety.CreateProperty<FrameworkTeam>(x => x.LeaderId);
        [Display(Name = "团队等级")]
        public ExcelPropety Level_Excel = ExcelPropety.CreateProperty<FrameworkTeam>(x => x.Level);
        [Display(Name = "组织")]
        public ExcelPropety Org_Excel = ExcelPropety.CreateProperty<FrameworkTeam>(x => x.OrgId);

	    protected override void InitVM()
        {
            Leader_Excel.DataType = ColumnDataType.ComboBox;
            Leader_Excel.ListItems = DC.Set<FrameworkUser>().GetSelectListItems(Wtm, y => y.Name);
            Org_Excel.DataType = ColumnDataType.ComboBox;
            Org_Excel.ListItems = DC.Set<FrameworkOrg>().GetSelectListItems(Wtm, y => y.OrgName);
        }

    }

    public class FrameworkTeamImportVM : BaseImportVM<FrameworkTeamTemplateVM, FrameworkTeam>
    {

    }

}
