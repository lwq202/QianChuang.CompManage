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
    [Table("FlowForm")]
    public partial class Form : PersistPoco
    {
        [Key]
        public string ID { get; set; }
        public Form()
        {
            this.Name = string.Empty;
            this.FrmType = 0;
            this.WebId = string.Empty;
            this.Fields = 0;
            this.ContentData = string.Empty;
            this.ContentParse = string.Empty;
            this.Content = string.Empty;
            this.SortCode = 0;
            this.DeleteMark = 0;
            this.DbName = string.Empty;
            this.Description = string.Empty;
        }

        /// <summary>
        /// 表单名称
        /// </summary>
        [Display(Name = "表单名称")]
        public string Name { get; set; }

        /// <summary>
        /// 表单类型，0：默认动态表单；1：Web自定义表单
        /// </summary>
        [Display(Name = "表单类型，0：默认动态表单；1：Web自定义表单")]
        public FrmTypeEnum FrmType { get; set; }
        /// <summary>
        /// 系统页面标识，当表单类型为用Web自定义的表单时，需要标识加载哪个页面
        /// </summary>
        [Display(Name = "系统页面标识，当表单类型为用Web自定义的表单时，需要标识加载哪个页面")]
        public string WebId { get; set; }
        /// <summary>
        /// 字段个数
        /// </summary>
        [Display(Name = "字段个数")]
        public int Fields { get; set; }
        /// <summary>
        /// 表单中的控件属性描述
        /// </summary>
        [Display(Name = "表单中的控件属性描述")]
        public string ContentData { get; set; }
        /// <summary>
        /// 表单控件位置模板
        /// </summary>
        [Display(Name = "表单控件位置模板")]
        public string ContentParse { get; set; }
        /// <summary>
        /// 表单原html模板未经处理的
        /// </summary>
        [Display(Name = "表单原html模板未经处理的")]
        public string Content { get; set; }
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
        /// 数据库名称
        /// </summary>
        [Display(Name = "数据库名称")]
        public string DbName { get; set; }
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
    public enum FrmTypeEnum{
        [Display(Name = "默认动态表单")]
        Default=0,
        [Display(Name = "Web自定义表单")]
        Web = 1,
    }
}
