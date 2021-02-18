using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Product
{
    /// <summary>
    /// 园区产品关系表
    /// </summary>
    public class ProductAreaInfo:PersistPoco
    {
        [Display(Name = "区域")]
        [Required]
        public Guid AreaId { get; set; }
        [Display(Name = "区域")]
        public ProductArea Area { get; set; }
        [Display(Name = "产品")]
        [Required]
        public Guid InfoId { get; set; }
        [Display(Name = "产品")]
        public ProductInfo Info { get; set; }

        [Display(Name = "零售价")] [Required] public decimal Price { get; set; } = 0;
        [Display(Name = "忽略字段")]
        public string IgnoreFields { get; set; }

        [Display(Name = "是否拥有")]
        public bool HasProduct { get; set; }


    }
}
