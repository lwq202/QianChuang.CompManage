using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using QianChuang.CompManage.Model.Flow;


namespace QianChuang.CompManage.ViewModel._Flow.FormVMs
{
    public partial class FormBatchVM : BaseBatchVM<Form, Form_BatchEdit>
    {
        public FormBatchVM()
        {
            ListVM = new FormListVM();
            LinkedVM = new Form_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Form_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
