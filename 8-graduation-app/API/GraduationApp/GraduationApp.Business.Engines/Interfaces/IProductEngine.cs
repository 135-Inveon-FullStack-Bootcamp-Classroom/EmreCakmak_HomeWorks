using GraduationApp.Business.Engines.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Interfaces
{
    public interface IProductEngine: IEngineBase
    {
        List<ProductOverViewModel> GetBestSellersProductList();
        List<ProductOverViewModel> GetAllProductList();
        ProductOverViewModel GetProduct(int productId);
        bool ProductExists(int id);
        void CreateProduct(ProductCreateModel productDto);
        void UpdateProduct(ProductUpdateModel productDto);
        void DeleteProduct(ProductOverViewModel productDto);
    }
}
