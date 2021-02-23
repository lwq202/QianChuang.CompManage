using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using QianChuang.CompManage.Model.Flow;


namespace QianChuang.CompManage.ViewModel._Flow.FormVMs
{
    public partial class FormListVM : BasePagedListVM<Form_View, FormSearcher>
    {

        protected override IEnumerable<IGridColumn<Form_View>> InitGridHeader()
        {
            return new List<GridColumn<Form_View>>{
                this.MakeGridHeader(x => x.ID),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.FrmType),
                this.MakeGridHeader(x => x.WebId),
                this.MakeGridHeader(x => x.Fields),
                this.MakeGridHeader(x => x.ContentData),
                this.MakeGridHeader(x => x.ContentParse),
                this.MakeGridHeader(x => x.Content),
                this.MakeGridHeader(x => x.SortCode),
                this.MakeGridHeader(x => x.DeleteMark),
                this.MakeGridHeader(x => x.DbName),
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeader(x => x.OrgId),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Form_View> GetSearchQuery()
        {
            var query = DC.Set<Form>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.FrmType, x=>x.FrmType)
                .CheckEqual(Searcher.Fields, x=>x.Fields)
                .Select(x => new Form_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    FrmType = x.FrmType,
                    WebId = x.WebId,
                    Fields = x.Fields,
                    ContentData = x.ContentData,
                    ContentParse = x.ContentParse,
                    Content = x.Content,
                    SortCode = x.SortCode,
                    DeleteMark = x.DeleteMark,
                    DbName = x.DbName,
                    Description = x.Description,
                    OrgId = x.OrgId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Form_View : Form{

    }
}
