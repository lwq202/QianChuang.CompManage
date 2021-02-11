using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkTeamVMs
{
    public partial class FrameworkTeamListVM : BasePagedListVM<FrameworkTeam_View, FrameworkTeamSearcher>
    {

        protected override IEnumerable<IGridColumn<FrameworkTeam_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkTeam_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Level),
                this.MakeGridHeader(x => x.OrgName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkTeam_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkTeam>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.LeaderId, x=>x.LeaderId)
                .CheckEqual(Searcher.Level, x=>x.Level)
                .CheckEqual(Searcher.OrgId, x=>x.OrgId)
                .Select(x => new FrameworkTeam_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Name_view = x.Leader.Name,
                    Level = x.Level,
                    OrgName_view = x.Org.OrgName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class FrameworkTeam_View : FrameworkTeam{
        [Display(Name = "_Admin.Name")]
        public String Name_view { get; set; }
        [Display(Name = "组织名称")]
        public String OrgName_view { get; set; }

    }
}
