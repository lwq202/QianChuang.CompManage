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
    /// 工作流模板信息表
    /// </summary>
    [Table("FlowScheme")]
    public class FlowScheme:PersistPoco
    {
        public FlowScheme()
        {
            this.SchemeCode = string.Empty;
            this.SchemeName = string.Empty;
            this.SchemeType = string.Empty;
            this.SchemeVersion = string.Empty;
            this.SchemeCanUser = string.Empty;
            this.SchemeContent = string.Empty;
            this.FrmId = string.Empty;
            this.FrmType = 0;
            this.AuthorizeType = 0;
            this.SortCode = 0;
            this.DeleteMark = 0;
            this.Description = string.Empty;
        }
        [Key]
        public string ID { get; set; }

        /// <summary>
        /// 流程编号
        /// </summary>
        [Display(Name = "流程编号")]
        public string SchemeCode { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        [Display(Name = "流程名称")]
        public string SchemeName { get; set; }
        /// <summary>
        /// 流程分类
        /// </summary>
        [Display(Name = "流程分类")]
        public string SchemeType { get; set; }
        /// <summary>
        /// 流程内容版本
        /// </summary>
        [Display(Name = "流程内容版本")]
        public string SchemeVersion { get; set; }
        /// <summary>
        /// 流程模板使用者
        /// </summary>
        [Display(Name = "流程模板使用者")]
        public string SchemeCanUser { get; set; }
        /// <summary>
        /// 流程内容
        /// </summary>
        [Display(Name = "流程内容")]
        public string SchemeContent { get; set; }
        /// <summary>
        /// 表单ID
        /// </summary>
        [Display(Name = "表单ID")]
        public string FrmId { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        [Display(Name = "表单类型")]
        public int FrmType { get; set; }
        /// <summary>
        /// 模板权限类型：0完全公开,1指定部门/人员
        /// </summary>
        [Display(Name = "模板权限类型：0完全公开,1指定部门/人员")]
        public int AuthorizeType { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        [Display(Name = "排序码")]
        public int SortCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        [Display(Name = "删除标记")]
        public int DeleteMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Description { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        [Display(Name = "所属部门")]
        public string OrgId { get; set; }
    }
}
