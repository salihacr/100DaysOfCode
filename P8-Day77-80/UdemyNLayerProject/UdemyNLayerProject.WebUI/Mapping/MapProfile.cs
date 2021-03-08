using AutoMapper;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.WebUI.DTOs;

namespace UdemyNLayerProject.WebUI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            /*
           CreateMap<Category, CategoryDto>();
           CreateMap<CategoryDto, Category>();
           // üsttekinin aynısı
           */
            CreateMap<Category, CategoryWithProductDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
        }
    }
}
