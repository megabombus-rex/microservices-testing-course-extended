namespace ShoppingProject.Coupon.API.Models.Dtos
{
    public class CouponDto
    {
        public string Code { get; set; }
        public double DiscountAmount { get; set; }
        public double MinAmount { get; set; }
    }
}
