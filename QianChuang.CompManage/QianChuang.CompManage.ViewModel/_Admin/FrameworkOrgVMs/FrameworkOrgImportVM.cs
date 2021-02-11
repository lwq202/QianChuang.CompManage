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
    public partial class FrameworkOrgTemplateVM : BaseTemplateVM
    {
        [Display(Name = "组织名称")]
        public ExcelPropety OrgName_Excel = ExcelPropety.CreateProperty<FrameworkOrg>(x => x.OrgName);
        [Display(Name = "组织名称简称")]
        public ExcelPropety SOrgName_Excel = ExcelPropety.CreateProperty<FrameworkOrg>(x => x.SOrgName);
        [Display(Name = "上级销售")]
        public ExcelPropety ManageUser_Excel = ExcelPropety.CreateProperty<FrameworkOrg>(x => x.ManageUserId);
        [Display(Name = "联系人")]
        public ExcelPropety LinkMan_Excel = ExcelPropety.CreateProperty<FrameworkOrg>(x => x.LinkMan);
        [Display(Name = "联系电话")]
        public ExcelPropety LinkPhone_Excel = ExcelPropety.CreateProperty<FrameworkOrg>(x => x.LinkPhone);
        [Display(Name = "组织类型")]
        public ExcelPropety OrgType_Excel = ExcelPropety.CreateProperty<FrameworkOrg>(x => x.OrgType);

	    protected override void InitVM()
        {
            ManageUser_Excel.DataType = ColumnDataType.ComboBox;
            ManageUser_Excel.ListItems = DC.Set<FrameworkUser>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class FrameworkOrgImportVM : BaseImportVM<FrameworkOrgTemplateVM, FrameworkOrg>
    {

    }

}
