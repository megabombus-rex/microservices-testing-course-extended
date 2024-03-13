using ShoppingProject.Coupon.API.Interfaces;
using ShoppingProject.Coupon.API.Models.Dtos;
using ShoppingProject.Coupon.Database.Contexts;
using ShoppingProject.Coupon.Database.Entities;

namespace ShoppingProject.Coupon.API.Services
{
    public class CouponService : ICouponService
    {
        private readonly CouponDbContext _dbContext;

        public CouponService(CouponDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CouponDto GetById(Guid id)
        {
            var coupons = _dbContext.Coupons
                .Where(x => x.Id == id);

            if (!coupons.Any())
            {
                throw new Exception("No coupon with this ID exists.");
            }

            var coupon = coupons.ToArray().First();

            return new CouponDto(
                Code: coupon.Code,
                DiscountAmount: coupon.DiscountAmount,
                MinAmount: coupon.MinAmount);
        }

        public CouponDto[] GetCoupons()
        {
            var coupons = _dbContext
                .Coupons;

            if (!coupons.Any())
            {
                throw new Exception("There are no coupons");
            }

            return coupons.Select(x => new CouponDto(x.Code, x.DiscountAmount, x.MinAmount)).ToArray();
        }
    }
}
