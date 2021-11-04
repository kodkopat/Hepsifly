using AutoMapper;
using System.Linq;
using System;
using Hepsifly.Domain.Models;
using Hepsifly.Domain.ViewModels.Category;
using Hepsifly.Domain.ViewModels.Product;

namespace Hepsifly.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Category
            CreateMap<Category, CategoryGetViewModel>();
            CreateMap<CategorySaveViewModel, Category>();
            #endregion
            #region Product
            CreateMap<Product, ProductGetViewModel>();
            CreateMap<ProductSaveViewModel, Product>();
            #endregion
        }
    }
}
