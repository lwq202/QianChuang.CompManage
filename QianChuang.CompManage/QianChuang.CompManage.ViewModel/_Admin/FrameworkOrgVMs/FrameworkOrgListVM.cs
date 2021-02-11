using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using QianChuang.CompManage.Model.Const;
using QianChuang.CompManage.Model.Framework;


namespace QianChuang.CompManage.ViewModel._Admin.FrameworkOrgVMs
{
    public partial class FrameworkOrgListVM : BasePagedListVM<FrameworkOrg_View, FrameworkOrgSearcher>
    {

        protected override IEnumerable<IGridColumn<FrameworkOrg_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkOrg_View>>{
                this.MakeGridHeader(x => x.OrgName),
                this.MakeGridHeader(x => x.SOrgName),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.LinkMan),
                this.MakeGridHeader(x => x.LinkPhone),
                this.MakeGridHeader(x => x.OrgType),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkOrg_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkOrg>()
                .CheckContain(Searcher.OrgName, x=>x.OrgName)
                .CheckContain(Searcher.SOrgName, x=>x.SOrgName)
                .CheckEqual(Searcher.ManageUserId, x=>x.ManageUserId)
                .CheckContain(Searcher.LinkMan, x=>x.LinkMan)
                .CheckContain(Searcher.LinkPhone, x=>x.LinkPhone)
                .CheckEqual(Searcher.OrgType, x=>x.OrgType)
                .Where(x=>!FrameworkConst.OrgReadOnlyId.Contains(x.ID))
                .Select(x => new FrameworkOrg_View
                {
				    ID = x.ID,
                    OrgName = x.OrgName,
                    SOrgName = x.SOrgName,
                    Name_view = x.ManageUser.Name,
                    LinkMan = x.LinkMan,
                    LinkPhone = x.LinkPhone,
                    OrgType = x.OrgType,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class FrameworkOrg_View : FrameworkOrg{
        [Display(Name = "_Admin.Name")]
        public String Name_view { get; set; }

    }
}
