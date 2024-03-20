using ShoppingProject.Coupon.API.Models.Dtos;

namespace ShoppingProject.Coupon.API.Interfaces
{
    public interface ICouponService
    {
        GetCouponDto GetById(Guid id);
        GetCouponDto[] GetCoupons();
        Guid CreateCoupon(CreateUpdateCouponDto dto);
        void ArchiveCoupon(Guid id);
        void RestoreCoupon(Guid id);
        void UpdateCoupon(Guid id, CreateUpdateCouponDto dto);
    }
}