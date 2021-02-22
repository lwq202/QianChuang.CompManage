using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Flow
{

    /// <summary>
    /// 工作流流程实例表
    /// </summary>
    [Table("FlowInstance")]
    public class FlowInstance:PersistPoco
    {
        public FlowInstance()
        {

            this.Code = string.Empty;
            this.CustomName = string.Empty;
            this.ActivityId = string.Empty;
            this.ActivityName = string.Empty;
            this.PreviousId = string.Empty;
            this.SchemeContent = string.Empty;
            this.SchemeId = string.Empty;
            this.DbName = string.Empty;
            this.FrmData = string.Empty;
            this.FrmType = 0;
            this.FrmContentData = string.Empty;
            this.FrmContentParse = string.Empty;
            this.FrmId = string.Empty;
            this.SchemeType = string.Empty;
            this.CreateTime = DateTime.Now;
            this.FlowLevel = 0;
            this.Description = string.Empty;
            this.IsFinish = false;
            this.MakerList = string.Empty;
        }
        [Key]
        public string ID { get; set; }
        /// <summary>
        /// 实例编号
        /// </summary>
        [Display(Name = "实例编号")]
        public string Code { get; set; }
        /// <summary>
        /// 自定义名称
        /// </summary>
        [Display(Name = "自定义名称")]
        public string CustomName { get; set; }
        /// <summary>
        /// 当前节点ID
        /// </summary>
        [Display(Name = "当前节点ID")]
        public string ActivityId { get; set; }
        /// <summary>
        /// 当前节点类型（0会签节点）
        /// </summary>
        [Display(Name = "当前节点类型（0会签节点）")]
        public int? ActivityType { get; set; }
        /// <summary>
        /// 当前节点名称
        /// </summary>
        [Display(Name = "当前节点名称")]
        public string ActivityName { get; set; }
        /// <summary>
        /// 前一个ID
        /// </summary>
        [Display(Name = "前一个ID")]
        public string PreviousId { get; set; }
        /// <summary>
        /// 流程模板内容
        /// </summary>
        [Display(Name = "流程模板内容")]
        public string SchemeContent { get; set; }
        /// <summary>
        /// 流程模板ID
        /// </summary>
        [Display(Name = "流程模板")]
        [Required]
        public string SchemeId { get; set; }

        [Display(Name = "流程模板")]
        public FlowScheme Scheme { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        [Display(Name = "数据库名称")]
        public string DbName { get; set; }
        /// <summary>
        /// 表单数据
        /// </summary>
        [Display(Name = "表单数据")]
        public string FrmData { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        [Display(Name = "表单类型")]
        public FrmTypeEnum FrmType { get; set; }
        /// <summary>
        /// 表单中的控件属性描述
        /// </summary>
        [Display(Name = "表单中的控件属性描述")]
        public string FrmContentData { get; set; }
        /// <summary>
        /// 表单控件位置模板
        /// </summary>
        [Display(Name = "表单控件位置模板")]
        public string FrmContentParse { get; set; }
        /// <summary>
        /// 表单ID
        /// </summary>
        [Display(Name = "表单ID")]
        public string FrmId { get; set; }

        [Display(Name = "表单")]
        public Form Frm { get; set; }
        /// <summary>
        /// 流程类型
        /// </summary>
        [Display(Name = "流程类型")]
        public string SchemeType { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        [Display(Name = "等级")]
        public int FlowLevel { get; set; }
        /// <summary>
        /// 实例备注
        /// </summary>
        [Display(Name = "实例备注")]
        public string Description { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        [Display(Name = "是否完成")]
        public bool IsFinish { get; set; }
        /// <summary>
        /// 执行人
        /// </summary>
        [Display(Name = "执行人")]
        public string MakerList { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        [Display(Name = "所属部门")]
        public string OrgId { get; set; }
    }
}
