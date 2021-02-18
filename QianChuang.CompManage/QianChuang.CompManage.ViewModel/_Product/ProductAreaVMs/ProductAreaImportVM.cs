using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Product;


namespace QianChuang.CompManage.ViewModel._Product.ProductAreaVMs
{
    public partial class ProductAreaTemplateVM : BaseTemplateVM
    {
        [Display(Name = "省")]
        public ExcelPropety Province_Excel = ExcelPropety.CreateProperty<ProductArea>(x => x.Province);
        [Display(Name = "市")]
        public ExcelPropety City_Excel = ExcelPropety.CreateProperty<ProductArea>(x => x.City);
        [Display(Name = "园区")]
        public ExcelPropety AreaName_Excel = ExcelPropety.CreateProperty<ProductArea>(x => x.AreaName);

	    protected override void InitVM()
        {
        }

    }

    public class ProductAreaImportVM : BaseImportVM<ProductAreaTemplateVM, ProductArea>
    {

    }

}
