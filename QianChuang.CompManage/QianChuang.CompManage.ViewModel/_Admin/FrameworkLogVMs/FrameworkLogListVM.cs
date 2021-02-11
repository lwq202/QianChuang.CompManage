using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkLogVMs
{
    public partial class FrameworkLogListVM : BasePagedListVM<FrameworkLog_View, FrameworkLogSearcher>
    {

        protected override IEnumerable<IGridColumn<FrameworkLog_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkLog_View>>{
                this.MakeGridHeader(x => x.Message),
                this.MakeGridHeader(x => x.Level),
                this.MakeGridHeader(x => x.TimeStamp),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkLog_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkLog>()
                .CheckContain(Searcher.Message, x=>x.Message)
                .CheckContain(Searcher.Level, x=>x.Level)
                .CheckBetween(Searcher.TimeStamp?.GetStartTime(), Searcher.TimeStamp?.GetEndTime(), x => x.TimeStamp, includeMax: false)
                .Select(x => new FrameworkLog_View
                {
				    ID = x.ID,
                    Message = x.Message,
                    Level = x.Level,
                    TimeStamp = x.TimeStamp,
                })
                .OrderByDescending(x => x.TimeStamp);
            return query;
        }

    }

    public class FrameworkLog_View : FrameworkLog{

    }
}
