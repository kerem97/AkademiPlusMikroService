using AkademiPlusMikroService.Discount.Dtos;
using AkademiPlusMikroService.Shared.Dtos;

namespace AkademiPlusMikroService.Discount.Services
{
    public interface IDiscountCouponService
    {
        Task<Response<List<ResultDiscountCouponDto>>> GetListAll();
        Task<Response<NoContent>> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto);
        Task<Response<NoContent>> UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task<Response<NoContent>> DeleteDiscountCoupon(int id);
    }
}
