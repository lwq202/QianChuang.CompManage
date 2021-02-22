using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Flow
{
    /// <summary>
    /// 工作流实例操作记录
    /// </summary>
    [Table("FlowInstanceOperationHistory")]
    public class FlowInstanceOperationHistory : TopBasePoco
    {

        public FlowInstanceOperationHistory()
        {
            this.InstanceId = string.Empty;
            this.Content = string.Empty;
            this.CreateDate = DateTime.Now;
            this.CreateUserId = Guid.Empty;
            this.CreateUserName = string.Empty;
        }
        [Key]
        public string ID { get; set; }
        /// <summary>
        /// 实例进程Id
        /// </summary>
        [Display(Name = "实例进程")]
        public string InstanceId { get; set; }

        [Display(Name = "实例进程")]
        public FlowInstance Instance { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        [Display(Name = "操作内容")]
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public System.DateTime CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        [Display(Name = "创建用户主键")]
        public Guid? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建用户
        /// </summary>
        [Display(Name = "创建用户")]
        public string CreateUserName { get; set; }
    }
}
