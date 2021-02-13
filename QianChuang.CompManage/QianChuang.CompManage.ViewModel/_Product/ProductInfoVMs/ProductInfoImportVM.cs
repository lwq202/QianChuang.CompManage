using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Product;


namespace QianChuang.CompManage.ViewModel._Product.ProductInfoVMs
{
    public partial class ProductInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "产品名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<ProductInfo>(x => x.Name);
        [Display(Name = "产品备注")]
        public ExcelPropety Remark_Excel = ExcelPropety.CreateProperty<ProductInfo>(x => x.Remark);
        [Display(Name = "表单Code")]
        public ExcelPropety FormCode_Excel = ExcelPropety.CreateProperty<ProductInfo>(x => x.FormCode);
        [Display(Name = "价格")]
        public ExcelPropety Price_Excel = ExcelPropety.CreateProperty<ProductInfo>(x => x.Price);
        [Display(Name = "标题")]
        public ExcelPropety Title_Excel = ExcelPropety.CreateProperty<ProductInfo>(x => x.Title);
        [Display(Name = "正文")]
        public ExcelPropety Content_Excel = ExcelPropety.CreateProperty<ProductInfo>(x => x.Content);

	    protected override void InitVM()
        {
        }

    }

    public class ProductInfoImportVM : BaseImportVM<ProductInfoTemplateVM, ProductInfo>
    {

    }

}
