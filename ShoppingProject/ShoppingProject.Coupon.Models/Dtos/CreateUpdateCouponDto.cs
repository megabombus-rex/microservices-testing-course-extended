namespace ShoppingProject.Coupon.Models.Dtos
{
    public record CreateUpdateCouponDto(string Code, double DiscountAmount, double MinAmount, DateTime ExpiryDate);
}
