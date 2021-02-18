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
    public partial class ProductAreaBatchVM : BaseBatchVM<ProductArea, ProductArea_BatchEdit>
    {
        public ProductAreaBatchVM()
        {
            ListVM = new ProductAreaListVM();
            LinkedVM = new ProductArea_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ProductArea_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
