namespace ShoppingProject.Coupon.API.Models.Dtos
{
    public record CouponDto(string Code, double DiscountAmount, double MinAmount, DateTime ExpiryDate);
}
