using ShoppingProject.Coupon.Database.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ShoppingProject.Coupon.Database.Entities
{
    public class Coupon : IArchivable
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public double MinAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsArchived { get; set; }
    }
}
