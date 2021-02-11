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
    /// <summary>
    /// 团队表，主要针对销售来的，
    /// </summary>
    [Table("FrameworkTeam")]
    public class FrameworkTeam : PersistPoco
    {
        private string _teamName;

        [Display(Name = " 团队名")]
        public string Name
        {
            get => _teamName;
            set
            {
                if (Leader!=null)
                {
                    _teamName = Leader.Name + "团队";
                }
                else
                {
                    _teamName = value;
                }

            }
        }

        [Display(Name = "领导者")]
        [Required]
        public Guid LeaderId { get; set; }
        [Display(Name = "领导者")]
        public FrameworkUser Leader { get; set; }

        [Display(Name = "成员")]
        
        public virtual IList<FrameworkUser> Members { get; set; }

        [Display(Name = "团队等级")]
        [Required]
        public TeamLevel Level { get; set; } = TeamLevel.One;

        /// <summary>
        /// 这个团队归属与某个组织
        /// </summary>
        [Required]
        [Display(Name = "组织")]
        public Guid OrgId { get; set; }
        [Display(Name = "组织")]
        public FrameworkOrg Org { get; set; }
        


    }

    public enum TeamLevel
    {
        [Display(Name = "一级")]
        One,
        [Display(Name = "二级")]
        Two,
        [Display(Name = "三级")]
        Three,
        [Display(Name = "四级")]
        Four,
        [Display(Name = "五级")]
        Five,
    }
}
