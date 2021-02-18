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
    public partial class ProductInfoBatchVM : BaseBatchVM<ProductInfo, ProductInfo_BatchEdit>
    {
        public ProductInfoBatchVM()
        {
            ListVM = new ProductInfoListVM();
            LinkedVM = new ProductInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ProductInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
