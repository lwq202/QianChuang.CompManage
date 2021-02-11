using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Framework
{
    [Table("FrameworkOrg")]
    public class FrameworkOrg: PersistPoco
    {

        [Display(Name = "组织名称")]
        [Required]
        public string OrgName { get; set; }
        [Display(Name = "组织名称简称")]
        [Required]
        public string SOrgName { get; set; }
        [Display(Name = "上级销售")]
        public Guid? ManageUserId { get; set; }
        [Display(Name = "上级销售")]
        public FrameworkUser ManageUser { get; set; }

        public List<FrameworkUser> Users { get; set; }

        [Display(Name = "联系人")]
        public string LinkMan { get; set; }
        [Display(Name = "联系电话")]
        public string LinkPhone { get; set; }

        [Required]
        [Display(Name = "组织类型")] 
        public OrgTypeEnum OrgType { get; set; } = OrgTypeEnum.User;
    }

    public enum OrgTypeEnum
    {
        [Display(Name = "管理组织")]
        Manage,
        [Display(Name = "其他组织")]
        Other,
        [Display(Name = "客户组织")]
        User,
    }
}
