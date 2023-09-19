using AkademiPlusMikroService.Catalog.Dtos.CategoryDtos;
using AkademiPlusMikroService.Catalog.Dtos.ProductDtos;
using AkademiPlusMikroService.Catalog.Models;
using AutoMapper;

namespace AkademiPlusMikroService.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
