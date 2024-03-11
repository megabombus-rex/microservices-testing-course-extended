using Microsoft.EntityFrameworkCore;
using ShoppingProject.Coupon.Database.Entities;

namespace ShoppingProject.Coupon.Database.Contexts
{
    public class CouponDbContext : DbContext
    {
        public CouponDbContext(DbContextOptions<CouponDbContext> options) : base (options)
        {
            
        }

        public DbSet<Entities.Coupon> Coupons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
