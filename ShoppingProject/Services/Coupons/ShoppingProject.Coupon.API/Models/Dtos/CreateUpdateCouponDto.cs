namespace ShoppingProject.Coupon.API.Models.Dtos
{
    public record CreateUpdateCouponDto(string Code, double DiscountAmount, double MinAmount, DateTime ExpiryDate);
}
