namespace ShoppingProject.Web.Models.Dtos
{
    public record CreateUpdateCouponDto(string Code, double DiscountAmount, double MinAmount, DateTime ExpiryDate);
}
