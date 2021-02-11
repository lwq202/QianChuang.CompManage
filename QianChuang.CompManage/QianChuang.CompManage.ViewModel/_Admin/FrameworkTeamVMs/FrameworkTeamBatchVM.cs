using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkTeamVMs
{
    public partial class FrameworkTeamBatchVM : BaseBatchVM<FrameworkTeam, FrameworkTeam_BatchEdit>
    {
        public FrameworkTeamBatchVM()
        {
            ListVM = new FrameworkTeamListVM();
            LinkedVM = new FrameworkTeam_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class FrameworkTeam_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
