using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.Flow.Frm
{
    /// <summary>
    /// 个独表单
    /// </summary>
    [Frm]
    [Table("FrmGeDu")]
    public class FrmGeDu:PersistPoco
    {
        [Display(Name = "企业名称")]
        public string CompName { get; set; }
        [Display(Name = "企业类型")]
        public string CompType { get; set; }
        [Display(Name = "备选企业名称")]
        public string CompNames { get; set; }
        [Display(Name = "出资额（万元）")]
        public string Amount { get; set; }



        [Display(Name = "经营范围")]
        public string BusinessScope { get; set; }
        [Display(Name = "投资人")]
        public Guid? InvestorId { get; set; }
        [Display(Name = "投资人")]
        public FrmPeople Investor { get; set; }
        [Display(Name = "财务负责人")]
        public Guid? FinanceId { get; set; }
        [Display(Name = "财务负责人")]
        public FrmPeople Finance { get; set; }

        [Display(Name = "计划开具发票品名")]
        public string PlanBillName { get; set; }

        [Display(Name = "印章")]
        public string Seals { get; set; }
    }
}
