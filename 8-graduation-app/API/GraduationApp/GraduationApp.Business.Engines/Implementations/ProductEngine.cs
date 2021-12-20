using AutoMapper;
using GraduationApp.Business.Engines.Interfaces;
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
    public class ProductEngine : IProductEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ProductOverViewModel> GetBestSellersProductList()
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            var products = productRepository.Get(p =>p.Bestseller)
               .Select(product => _mapper.Map<ProductOverViewModel>(product)).ToList();
            return products;
        }
        public ProductOverViewModel GetProduct(int productId)
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            var product = productRepository.GetById(productId);
            var productDto=_mapper.Map<ProductOverViewModel>(product);
            
            return productDto;
        }

        public List<ProductOverViewModel> GetAllProductList()
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            var products = productRepository.GetAll()
                .Select(product => _mapper.Map<ProductOverViewModel>(product)).ToList();
            return products;
        }
        public void CreateProduct(ProductCreateModel productDto)
        {
            var product = _mapper.Map<ProductEntity>(productDto);
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            productRepository.Add(product);
            _unitOfWork.SaveChanges();
               
        }
        public void UpdateProduct(ProductUpdateModel productDto)
        {
            var product = _mapper.Map<ProductEntity>(productDto);
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            productRepository.Update(product);
            _unitOfWork.SaveChanges();

        }
        public void DeleteProduct(ProductOverViewModel productDto)
        {
            var product = _mapper.Map<ProductEntity>(productDto);
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            productRepository.Delete(product);
            _unitOfWork.SaveChanges();

        }
        //public bool ProductExists(string name)
        //{
        //    var productRepository = _unitOfWork.GetRepository<ProductEntity>();
        //    productRepository.IsExists()
        //    bool productName = _db.NationalParks.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
        //    return productName;
        //}

        public bool ProductExists(int id)
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();

            return productRepository.IsExists(id);
        }
    }
}
