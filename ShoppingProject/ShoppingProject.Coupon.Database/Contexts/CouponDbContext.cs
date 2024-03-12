using Microsoft.EntityFrameworkCore;
using ShoppingProject.Coupon.Database.Entities;

namespace ShoppingProject.Coupon.Database.Contexts
{
    public class CouponDbContext : DbContext
    {
        public CouponDbContext()
        {
        }

        public CouponDbContext(DbContextOptions<CouponDbContext> options) : base (options)
        {
            
        }

        public DbSet<Entities.Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Coupon>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.DiscountAmount).IsRequired();
            });

            SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Coupon>().HasData(new Entities.Coupon
            {
                Id = new Guid("4f49c86f-09ac-4fdf-9028-5910c6fa50b7"),
                Code = "OFF10",
                DiscountAmount = 10,
                MinAmount = 30,
                ExpiryDate = new DateTime(2025, 10, 25)
            });

            modelBuilder.Entity<Entities.Coupon>().HasData(new Entities.Coupon
            {
                Id = new Guid("78c728dc-679f-41ad-add6-8b7a61d386b9"),
                Code = "OFF20",
                DiscountAmount = 20,
                MinAmount = 60,
                ExpiryDate = new DateTime(2025, 10, 25)
            });
        }
    }
}
