using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingProject.Coupon.API.Interfaces;
using ShoppingProject.Coupon.API.Models.Dtos;
using ShoppingProject.Coupon.Database.Contexts;
using ShoppingProject.Coupon.Database.Entities;

namespace ShoppingProject.Coupon.API.Services
{
    public class CouponService : ICouponService
    {
        private readonly CouponDbContext _dbContext;
        private readonly IMapper _mapper;

        public CouponService(CouponDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetCouponDto GetById(Guid id)
        {
            var coupons = _dbContext.Coupons
                .Where(x => x.Id == id);

            if (!coupons.Any())
            {
                throw new Exception("No coupon with this ID exists.");
            }

            var coupon = coupons.ToArray().First();

            return _mapper.Map<GetCouponDto>(coupon);
        }

        public GetCouponDto[] GetCoupons()
        {
            var coupons = _dbContext
                .Coupons;

            if (!coupons.Any())
            {
                throw new Exception("There are no coupons");
            }

            return coupons.Select(x => _mapper.Map<GetCouponDto>(x)).ToArray();
        }

        public void UpdateCoupon(Guid id, CreateUpdateCouponDto dto)
        {
            if (!_dbContext.Coupons.Any(x => x.Id == id))
            {
                throw new Exception("Coupon with this Id does not exist.");
            }

            if (_dbContext.Coupons.Any(x => x.Code == dto.Code && !x.IsArchived && x.Id != id))
            {
                throw new Exception("Coupon with the same code is already active.");
            }

            var coupon = _dbContext.Coupons.FirstOrDefault(x => x.Id == id);

            coupon!.Code = dto.Code;
            coupon!.DiscountAmount = dto.DiscountAmount;
            coupon!.MinAmount = dto.MinAmount;
            coupon!.ExpiryDate = dto.ExpiryDate;

            _dbContext.Coupons.Update(coupon);
            _dbContext.SaveChanges();
        }

        public Guid CreateCoupon(CreateUpdateCouponDto dto)
        {
            if (_dbContext.Coupons.Any(x => x.Code == dto.Code && !x.IsArchived))
            {
                throw new Exception("Coupon with the same code is already active.");
            }

            var coupon = new Database.Entities.Coupon()
            {
                Id = Guid.NewGuid(),
                Code = dto.Code,
                DiscountAmount = dto.DiscountAmount,
                MinAmount = dto.MinAmount,
                ExpiryDate = dto.ExpiryDate,
                IsArchived = false
            };

            _dbContext.Coupons.Add(coupon);
            _dbContext.SaveChanges();

            return coupon.Id;
        }

        public void ArchiveCoupon(Guid id)
        {
            if(!_dbContext.Coupons.Any(x => x.Id == id))
            {
                throw new Exception("Coupon with this Id does not exist.");
            }

            var coupon = _dbContext.Coupons.FirstOrDefault(x => x.Id == id);
            coupon!.IsArchived = true;

            _dbContext.Update(coupon);
            _dbContext.SaveChanges();
        }

        public void RestoreCoupon(Guid id)
        {
            if (!_dbContext.Coupons.Any(x => x.Id == id))
            {
                throw new Exception("Coupon with this Id does not exist.");
            }

            var coupon = _dbContext.Coupons.FirstOrDefault(x => x.Id == id);

            if(_dbContext.Coupons.Any(x => x.Code == coupon!.Code && x.IsArchived))
            {
                throw new Exception("Coupon with the same code is already active.");
            }

            coupon!.IsArchived = false;

            _dbContext.Update(coupon);
            _dbContext.SaveChanges();
        }
    }
}
