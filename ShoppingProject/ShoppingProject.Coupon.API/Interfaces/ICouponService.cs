using ShoppingProject.Coupon.API.Models.Dtos;

namespace ShoppingProject.Coupon.API.Interfaces
{
    public interface ICouponService
    {
        CouponDto GetById(Guid id);
        CouponDto[] GetCoupons();
    }
}