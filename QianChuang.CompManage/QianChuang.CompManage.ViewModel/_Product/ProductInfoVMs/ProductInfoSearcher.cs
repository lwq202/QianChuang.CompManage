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
    public partial class ProductInfoSearcher : BaseSearcher
    {
        [Display(Name = "产品名称")]
        public String Name { get; set; }
        [Display(Name = "表单Code")]
        public String FormCode { get; set; }
        [Display(Name = "标题")]
        public String Title { get; set; }

        protected override void InitVM()
        {
        }

    }
}
