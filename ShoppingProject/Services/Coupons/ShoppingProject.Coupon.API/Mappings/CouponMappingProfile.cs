using AutoMapper;
using ShoppingProject.Coupon.API.Models.Dtos;

namespace ShoppingProject.Coupon.API.Mappings
{
    public class CouponMappingProfile : Profile
    {
        public CouponMappingProfile()
        {
            CreateMap<CreateUpdateCouponDto, Database.Entities.Coupon>();
            CreateMap<Database.Entities.Coupon, GetCouponDto>();
        }
    }
}
