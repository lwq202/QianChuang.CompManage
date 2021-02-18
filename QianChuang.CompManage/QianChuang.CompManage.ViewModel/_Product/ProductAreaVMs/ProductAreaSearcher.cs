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
    public partial class ProductAreaSearcher : BaseSearcher
    {
        [Display(Name = "省")]
        public String Province { get; set; }
        [Display(Name = "市")]
        public String City { get; set; }
        [Display(Name = "园区")]
        public String AreaName { get; set; }

        protected override void InitVM()
        {
        }

    }
}
