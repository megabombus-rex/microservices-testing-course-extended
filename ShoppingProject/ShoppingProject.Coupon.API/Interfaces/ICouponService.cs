using ShoppingProject.Coupon.API.Models.Dtos;

namespace ShoppingProject.Coupon.API.Interfaces
{
    public interface ICouponService
    {
        CouponDto GetById(Guid id);
        CouponDto[] GetCoupons();
        Guid CreateCoupon(CouponDto dto);
        void ArchiveCoupon(Guid id);
        void RestoreCoupon(Guid id);
        void UpdateCoupon(Guid id, CouponDto dto);
    }
}