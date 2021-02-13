using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Product
{
    /// <summary>
    /// 园区表
    /// </summary>
    [Table("ProductArea")]
    public class ProductArea:PersistPoco
    {
        [Display(Name = "省")]
        [Required]
        public string Province { get; set; }
        [Display(Name = "市")]
        [Required]
        public string City { get; set; }
        [Display(Name = "园区")]
        [Required]
        public string AreaName { get; set; }

        public List<ProductAreaInfo> ProductAreaInfos { get; set; }
    }
}
