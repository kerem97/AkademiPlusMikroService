﻿using AkademiPlusMikroService.Basket.Dtos;
using AkademiPlusMikroService.Shared.Dtos;
using System.Text.Json;

namespace AkademiPlusMikroService.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> DeleteBasket(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepet bulunamadı", 404);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket)) { return Response<BasketDto>.Fail("Sepet bulunamadı", 404); }


            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);


        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepet güncellenirken bir hata meydana geldi", 500);
        }
    }
}
