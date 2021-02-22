using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Flow.Frm
{
    /// <summary>
    /// 人员描述
    /// </summary>
    public class FrmPeople:TopBasePoco
    {
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "实名手机")]
        public string TelPhone { get; set; }
        [Display(Name = "身份证号码")]
        public string LegalIdentityNum { get; set; }
        [Display(Name = "身份证有效期")]
        public string LegalLimitDate { get; set; }
        [Display(Name = "身份证地址")]
        public string LegalAddress { get; set; }
        [Display(Name = "民族")]
        public string Nation { get; set; }
        [Display(Name = "文化程度")]
        public string Education { get; set; }
        [Display(Name = "政治面貌")]
        public string Political { get; set; }
        [Display(Name = "邮政编码")]
        public string ZipCode { get; set; }
        [Display(Name = "身份证正")]
        public Guid? IdentityId { get; set; }
        [Display(Name = "身份证正")]
        public FileAttachment Identity { get; set; }
        [Display(Name = "身份证反")]
        public Guid? IdentityBackId { get; set; }
        [Display(Name = "身份证反")]
        public FileAttachment IdentityBack { get; set; }
    }
}
