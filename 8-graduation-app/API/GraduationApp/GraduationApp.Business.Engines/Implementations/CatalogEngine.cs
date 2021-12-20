using AutoMapper;
using GraduationApp.Business.Engines.Interfaces;
using GraduationApp.Business.Engines.Models.Category;
using GraduationApp.Business.Engines.Models.Product;
using GraduationApp.Data.DAL.UnitOfWork;
using GraduationApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Implementations
{
    public class CatalogEngine : ICatalogEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CatalogEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<CategoryOverViewModel> GetAllCategoryList()
        {
            var categoryRepository = _unitOfWork.GetRepository<CategoryEntity>();
            var categories = categoryRepository.GetAll()
                .Select(category => _mapper.Map<CategoryOverViewModel>(category)).ToList();
            return categories;
        }

        public void CreateCategory(CategoryCreateModel categoryDto)
        {
            var category = _mapper.Map<CategoryEntity>(categoryDto);
            var categoryRepository = _unitOfWork.GetRepository<CategoryEntity>();
            categoryRepository.Add(category);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCategory(CategoryOverViewModel categoryDto)
        {
            var category = _mapper.Map<CategoryEntity>(categoryDto);
            var categoryRepository = _unitOfWork.GetRepository<CategoryEntity>();
            categoryRepository.Delete(category);
            _unitOfWork.SaveChanges();
        }

        public CategoryOverViewModel GetCategory(int categoryId)
        {
            var categoryRepository = _unitOfWork.GetRepository<CategoryEntity>();
            var category = categoryRepository.GetById(categoryId);
            var productDto = _mapper.Map<CategoryOverViewModel>(category);

            return productDto;
        }

        public List<ProductOverViewModel> GetProductListByCategoryIdForCatalog(int categoryId)
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();         
            var products = productRepository.Get(q => q.CategoryId == categoryId)
                .Select(product => _mapper.Map<ProductOverViewModel>(product)).ToList();
            return products;
        }

        public void UpdateCategory(CategoryOverViewModel categoryDto)
        {
            var category = _mapper.Map<CategoryEntity>(categoryDto);
            var categoryRepository = _unitOfWork.GetRepository<CategoryEntity>();
            categoryRepository.Update(category);
            _unitOfWork.SaveChanges();
        }

        public bool CategoryExists(int id)
        {
            var categoryRepository = _unitOfWork.GetRepository<CategoryEntity>();

            return categoryRepository.IsExists(id);
        }
    }
}
