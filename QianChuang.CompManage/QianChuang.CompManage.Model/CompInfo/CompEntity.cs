using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.Model.CompInfo
{

    public class CompEntity:PersistPoco
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CardType { get; set; }

    }
}
