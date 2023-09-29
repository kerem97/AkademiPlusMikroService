using AkademiPlusMikroService.Basket.Dtos;
using AkademiPlusMikroService.Shared.Dtos;

namespace AkademiPlusMikroService.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> DeleteBasket(string userId);



    }
}
