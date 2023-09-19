using AkademiPlusMikroService.Catalog.Dtos.CategoryDtos;
using AkademiPlusMikroService.Catalog.Models;
using AkademiPlusMikroService.Catalog.Settings;
using AkademiPlusMikroService.Shared.Dtos;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiPlusMikroService.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);


            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            var value = _mapper.Map<Category>(createCategoryDto);

            await _categoryCollection.InsertOneAsync(value);

            return Response<NoContent>.Success(200);

        }

        public async Task<Response<NoContent>> DeleteCategory(string id)
        {
            var values = await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultCategoryDto>>> GetAllCategories()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();

            return Response<List<ResultCategoryDto>>.Success(_mapper.Map<List<ResultCategoryDto>>(values), 200);
        }

        public async Task<Response<ResultCategoryDto>> GetByIdCategory(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();

            if (values == null)
            {
                return Response<ResultCategoryDto>.Fail("Kategori bulunamadı", 404);
            }

            else
            {
                return Response<ResultCategoryDto>.Success(_mapper.Map<ResultCategoryDto>(values), 200);
            }
        }

        public async Task<Response<NoContent>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);

            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);


            if (result == null)
            {
                return Response<NoContent>.Fail("Kategori bulunamadı", 404);
            }

            return Response<NoContent>.Success(204);
        }
    }
}
