using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Framework
{
    /// <summary>
    /// FrameworkUser
    /// </summary>
    [Table("FrameworkUsers")]
    public class FrameworkUser : FrameworkUserBase
    {
        [Display(Name = "_Admin.Email")]
        [RegularExpression("^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "Validate.{0}formaterror")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Email { get; set; }

        [Display(Name = "_Admin.Gender")]
        public GenderEnum? Gender { get; set; }

        [Display(Name = "_Admin.CellPhone")]
        [RegularExpression("^[1][3-9]\\d{9}$", ErrorMessage = "Validate.{0}formaterror")]
        public string CellPhone { get; set; }

        [Display(Name = "_Admin.HomePhone")]
        [StringLength(30, ErrorMessage = "Validate.{0}stringmax{1}")]
        [RegularExpression("^[-0-9\\s]{8,30}$", ErrorMessage = "Validate.{0}formaterror")]
        public string HomePhone { get; set; }

        [Display(Name = "_Admin.Address")]
        [StringLength(200, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Address { get; set; }

        [Display(Name = "_Admin.ZipCode")]
        [RegularExpression("^[0-9]{6,6}$", ErrorMessage = "Validate.{0}formaterror")]
        public string ZipCode { get; set; }

        //public virtual List<FrameworkOrg> FrameworkOrgs { get; set; }

        /*
         * 一个用户必须属于一个组织，系统固定两个默认组织：
         * 1.乾创组织
         * 2.客户组织
         */
        [Display(Name = "组织")]
        [Required]
        public Guid OrgId { get; set; }
        [Display(Name = "组织")]
        public FrameworkOrg Org { get; set; }

        public List<FrameworkOrg> Orgs { get; set; }
        /*
         * 这个主要是针对销售的
         * 销售可以组建团队
         */
        [Display(Name = "团队")]
        public Guid? TeamId { get; set; }
        [Display(Name = "团队")]
        public FrameworkTeam Team { get; set; }

        public FrameworkTeam? ManageTeam { get; set; }
    }
}
