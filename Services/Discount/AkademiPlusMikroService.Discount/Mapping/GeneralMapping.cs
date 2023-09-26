using AkademiPlusMikroService.Discount.Dtos;
using AkademiPlusMikroService.Discount.Models;
using AutoMapper;

namespace AkademiPlusMikroService.Discount.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<DiscountCoupon, ResultDiscountCouponDto>().ReverseMap();
            CreateMap<DiscountCoupon, CreateDiscountCouponDto>().ReverseMap();
            CreateMap<DiscountCoupon, UpdateDiscountCouponDto>().ReverseMap();
        }
    }
}
