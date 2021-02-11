using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkOrgVMs
{
    public partial class FrameworkOrgBatchVM : BaseBatchVM<FrameworkOrg, FrameworkOrg_BatchEdit>
    {
        public FrameworkOrgBatchVM()
        {
            ListVM = new FrameworkOrgListVM();
            LinkedVM = new FrameworkOrg_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class FrameworkOrg_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
