using AutoMapper;
using ShoppingProject.Coupon.API.Models.Dtos;

namespace ShoppingProject.Coupon.API.Mappings
{
    public class CouponMappingProfile : Profile
    {
        public CouponMappingProfile()
        {
            CreateMap<CouponDto, Database.Entities.Coupon>();
            CreateMap<Database.Entities.Coupon, CouponDto > ();
        }
    }
}
