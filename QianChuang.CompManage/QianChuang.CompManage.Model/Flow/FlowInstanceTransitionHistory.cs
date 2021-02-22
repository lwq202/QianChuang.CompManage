using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Flow
{
    /// <summary>
    /// 工作流实例流转历史记录
    /// </summary>
    [Table("FlowInstanceTransitionHistory")]
    public class FlowInstanceTransitionHistory:TopBasePoco
    {
        [Key]
        public string ID { get; set; }

        public string InstanceId { get; set; }
        public FlowInstance Instance { get; set; }
        public string FromNodeId { get; set; }
        public string FromNodeType { get; set; }
        public string FromNodeName { get; set; }
        public string ToNodeId { get; set; }
        public string ToNodeType { get; set; }
        public string ToNodeName { get; set; }
        public string TransitionState { get; set; }
        public bool IsFinish { get; set; }
        /// <summary>
        /// 转化时间
        /// </summary>
        [Display(Name = "转化时间")]
        public System.DateTime CreateDate { get; set; }
        /// <summary>
        /// 操作人Id
        /// </summary>
        [Display(Name = "操作人Id")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// 操作人名称
        /// </summary>
        [Display(Name = "操作人名称")]
        public string CreateUserName { get; set; }
    }
}
