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
    public partial class FormTemplateVM : BaseTemplateVM
    {
        public ExcelPropety ID_Excel = ExcelPropety.CreateProperty<Form>(x => x.ID);
        [Display(Name = "表单名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Form>(x => x.Name);
        [Display(Name = "表单类型，0：默认动态表单；1：Web自定义表单")]
        public ExcelPropety FrmType_Excel = ExcelPropety.CreateProperty<Form>(x => x.FrmType);
        [Display(Name = "系统页面标识，当表单类型为用Web自定义的表单时，需要标识加载哪个页面")]
        public ExcelPropety WebId_Excel = ExcelPropety.CreateProperty<Form>(x => x.WebId);
        [Display(Name = "字段个数")]
        public ExcelPropety Fields_Excel = ExcelPropety.CreateProperty<Form>(x => x.Fields);
        [Display(Name = "表单中的控件属性描述")]
        public ExcelPropety ContentData_Excel = ExcelPropety.CreateProperty<Form>(x => x.ContentData);
        [Display(Name = "表单控件位置模板")]
        public ExcelPropety ContentParse_Excel = ExcelPropety.CreateProperty<Form>(x => x.ContentParse);
        [Display(Name = "表单原html模板未经处理的")]
        public ExcelPropety Content_Excel = ExcelPropety.CreateProperty<Form>(x => x.Content);
        [Display(Name = "排序码")]
        public ExcelPropety SortCode_Excel = ExcelPropety.CreateProperty<Form>(x => x.SortCode);
        [Display(Name = "删除标记")]
        public ExcelPropety DeleteMark_Excel = ExcelPropety.CreateProperty<Form>(x => x.DeleteMark);
        [Display(Name = "数据库名称")]
        public ExcelPropety DbName_Excel = ExcelPropety.CreateProperty<Form>(x => x.DbName);
        [Display(Name = "备注")]
        public ExcelPropety Description_Excel = ExcelPropety.CreateProperty<Form>(x => x.Description);
        [Display(Name = "所属部门")]
        public ExcelPropety OrgId_Excel = ExcelPropety.CreateProperty<Form>(x => x.OrgId);

	    protected override void InitVM()
        {
        }

    }

    public class FormImportVM : BaseImportVM<FormTemplateVM, Form>
    {

    }

}
