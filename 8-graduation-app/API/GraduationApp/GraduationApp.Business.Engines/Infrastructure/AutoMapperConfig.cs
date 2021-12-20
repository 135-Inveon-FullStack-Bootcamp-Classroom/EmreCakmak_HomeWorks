using AutoMapper;
using GraduationApp.Business.Engines.Models.Category;
using GraduationApp.Business.Engines.Models.Order;
using GraduationApp.Business.Engines.Models.Product;
using GraduationApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Infrastructure
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductEntity, ProductOverViewModel>().ReverseMap();
            CreateMap<ProductEntity, ProductCreateModel>().ReverseMap();
            CreateMap<ProductEntity, ProductUpdateModel>().ReverseMap();
            CreateMap<CategoryEntity, CategoryOverViewModel>().ReverseMap();
            CreateMap<CategoryEntity, CategoryCreateModel>().ReverseMap();
            CreateMap<OrderEntity, OrderOverViewModel>().ReverseMap();
        }
    }
}
