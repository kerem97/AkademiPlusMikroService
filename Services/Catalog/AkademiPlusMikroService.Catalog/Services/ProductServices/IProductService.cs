﻿using AkademiPlusMikroService.Catalog.Dtos.CategoryDtos;
using AkademiPlusMikroService.Catalog.Dtos.ProductDtos;
using AkademiPlusMikroService.Shared.Dtos;

namespace AkademiPlusMikroService.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDto>>> GetAllProducts();

        Task<Response<ResultProductDto>> GetByIdProduct(string id);

        Task<Response<NoContent>> CreateProduct(CreateProductDto createProductDto);

        Task<Response<NoContent>> UpdateProduct(UpdateProductDto updateProductDto);

        Task<Response<NoContent>> DeleteProduct(string id);
    }
}
