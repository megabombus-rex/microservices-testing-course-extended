namespace ShoppingProject.Coupon.Models.Dtos
{
    public record GetCouponDto(Guid Id, string Code, double DiscountAmount, double MinAmount, DateTime ExpiryDate);
}
