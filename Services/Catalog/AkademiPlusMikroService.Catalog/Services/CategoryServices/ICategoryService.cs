﻿using AkademiPlusMikroService.Catalog.Dtos.CategoryDtos;
using AkademiPlusMikroService.Shared.Dtos;

namespace AkademiPlusMikroService.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDto>>> GetAllCategories();

        Task<Response<ResultCategoryDto>> GetByIdCategory(string id);

        Task<Response<NoContent>> CreateCategory(CreateCategoryDto createCategoryDto);

        Task<Response<NoContent>> UpdateCategory(UpdateCategoryDto updateCategoryDto);

        Task<Response<NoContent>> DeleteCategory(string id);
    }
}
