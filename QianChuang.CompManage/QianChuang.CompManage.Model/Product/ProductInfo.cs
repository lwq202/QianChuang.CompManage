using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Product
{
    /// <summary>
    /// 产品信息表
    /// </summary>
    public class ProductInfo:PersistPoco
    {
        [Display(Name = "产品名称")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "产品备注")]
        [Required]
        public string Remark { get; set; }
        [Display(Name = "表单")]
        public string FormCode { get; set; }

        [Display(Name = "价格")]
        public decimal? Price { get; set; }

        [Display(Name = "标题")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "图片")]
        [Required]
        public Guid? ImageId { get; set; }
        [Display(Name = "图片")]
        public FileAttachment Image { get; set; }

        [Display(Name = "正文")]
        [Required]
        [Column(TypeName="ntext")]
        [JsonConverter(typeof(JsonStringConverter))]
        public string Content { get; set; }

        [Display(Name = "产品类型")]
        [Required]
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.New;
    }

    public enum ProductTypeEnum
    {
        [Display(Name = "新增")]
        New,
        [Display(Name = "普通")]
        Normal,
    }
}
