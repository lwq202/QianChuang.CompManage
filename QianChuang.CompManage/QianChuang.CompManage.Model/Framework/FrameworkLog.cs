using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Framework
{
    [Table("FrameworkLogs")]
    public class FrameworkLog:TopBasePoco
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }
        [Display(Name = "消息")]
        [MaxLength(4000)]
        public string Message { get; set; }
        [Display(Name = "消息模板")]
        [MaxLength(4000)]
        public string MessageTemplate { get; set; }
        [Display(Name = "等级")]
        [MaxLength(100)]
        public string Level { get; set; }
        [Display(Name = "时间")]
        public DateTime? TimeStamp { get; set; }
        [Display(Name = "错误明显")]
        [Column(TypeName = "ntext")]
        public string Exception { get; set; }
        [Display(Name = "属性")]
        [MaxLength(4000)]
        public string Properties { get; set; }
        [Display(Name = "日志事件")]
        [MaxLength(4000)]
        public string LogEvent { get; set; }
    }
}
