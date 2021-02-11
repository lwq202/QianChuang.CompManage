using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkLogVMs
{
    public partial class FrameworkLogBatchVM : BaseBatchVM<FrameworkLog, FrameworkLog_BatchEdit>
    {
        public FrameworkLogBatchVM()
        {
            ListVM = new FrameworkLogListVM();
            LinkedVM = new FrameworkLog_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class FrameworkLog_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
