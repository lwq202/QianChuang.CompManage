using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using QianChuang.CompManage.Model.Product;


namespace QianChuang.CompManage.ViewModel._Product.ProductAreaVMs
{
    public partial class ProductAreaListVM : BasePagedListVM<ProductArea_View, ProductAreaSearcher>
    {

        protected override IEnumerable<IGridColumn<ProductArea_View>> InitGridHeader()
        {
            return new List<GridColumn<ProductArea_View>>{
                this.MakeGridHeader(x => x.Province),
                this.MakeGridHeader(x => x.City),
                this.MakeGridHeader(x => x.AreaName),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ProductArea_View> GetSearchQuery()
        {
            var query = DC.Set<ProductArea>()
                .CheckContain(Searcher.Province, x=>x.Province)
                .CheckContain(Searcher.City, x=>x.City)
                .CheckContain(Searcher.AreaName, x=>x.AreaName)
                .Select(x => new ProductArea_View
                {
				    ID = x.ID,
                    Province = x.Province,
                    City = x.City,
                    AreaName = x.AreaName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ProductArea_View : ProductArea{

    }
}
