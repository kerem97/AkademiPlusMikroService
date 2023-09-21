using AkademiPlusMikroService.Catalog.Dtos.ProductDtos;
using AkademiPlusMikroService.Catalog.Models;
using AkademiPlusMikroService.Catalog.Settings;
using AkademiPlusMikroService.Shared.Dtos;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiPlusMikroService.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task<Response<NoContent>> CreateProduct(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteProduct(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultProductDto>>> GetAllProducts()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();

            return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);
        }

        public async Task<Response<ResultProductDto>> GetByIdProduct(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();

            if (values == null)
            {
                return Response<ResultProductDto>.Fail("Ürün bulunamadı", 404);
            }

            return Response<ResultProductDto>.Success(_mapper.Map<ResultProductDto>(values), 200);
        }

        public async Task<Response<NoContent>> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);

            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);

            return Response<NoContent>.Success(200);
        }
    }
}
