using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using QianChuang.CompManage.Model.Product;


namespace QianChuang.CompManage.ViewModel._Product.ProductInfoVMs
{
    public partial class ProductInfoListVM : BasePagedListVM<ProductInfo_View, ProductInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<ProductInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<ProductInfo_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Remark),
                this.MakeGridHeader(x => x.FormCode),
                this.MakeGridHeader(x => x.Price),
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.ImageId).SetFormat(ImageIdFormat),
                this.MakeGridHeader(x => x.Content),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> ImageIdFormat(ProductInfo_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.ImageId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.ImageId,640,480),
            };
        }


        public override IOrderedQueryable<ProductInfo_View> GetSearchQuery()
        {
            var query = DC.Set<ProductInfo>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.FormCode, x=>x.FormCode)
                .CheckContain(Searcher.Title, x=>x.Title)
                .Select(x => new ProductInfo_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Remark = x.Remark,
                    FormCode = x.FormCode,
                    Price = x.Price,
                    Title = x.Title,
                    ImageId = x.ImageId,
                    Content = x.Content,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ProductInfo_View : ProductInfo{

    }
}
