using GraduationApp.Business.Engines.Models.Category;
using GraduationApp.Business.Engines.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Interfaces
{
    public interface ICatalogEngine:IEngineBase
    {
        List<ProductOverViewModel> GetProductListByCategoryIdForCatalog(int categoryId);
        CategoryOverViewModel GetCategory(int categoryId);
        List<CategoryOverViewModel> GetAllCategoryList();
        bool CategoryExists(int id);
        void CreateCategory(CategoryCreateModel categoryDto);
        void UpdateCategory(CategoryOverViewModel categoryDto);
        void DeleteCategory(CategoryOverViewModel categoryDto);
    }
}
