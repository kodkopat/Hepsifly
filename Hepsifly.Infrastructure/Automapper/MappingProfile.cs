using AutoMapper;
using System.Linq;
using System;
using Hepsifly.Domain.Models;
using Hepsifly.Domain.ViewModels.Category;
using Hepsifly.Domain.ViewModels.Product;
using Hepsifly.Domain.ViewModels.Reservation;

namespace Hepsifly.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Category
            CreateMap<Category, CategoryGetViewModel>().ReverseMap();
            CreateMap<CategorySaveViewModel, Category>().ReverseMap();
            #endregion
            #region Product
            CreateMap<Product, ProductGetViewModel>().ReverseMap();
            CreateMap<ProductSaveViewModel, Product>().ReverseMap();
            #endregion
            #region Reservation
            CreateMap<Reservation, ReservationGetViewModel>().ReverseMap();
            CreateMap<ReservationSaveViewModel, Reservation>().ReverseMap();
            #endregion
        }
    }
}
