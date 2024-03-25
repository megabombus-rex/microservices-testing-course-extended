using ShoppingProject.Web.Models.Dtos;

namespace ShoppingProject.Web.Services.Interfaces
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponByIdAsync(Guid id);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> CreateCouponAsync(CreateUpdateCouponDto dto);
        Task<ResponseDto?> UpdateCouponAsync(CreateUpdateCouponDto dto);
        Task<ResponseDto?> ArchiveCouponAsync(Guid id);
        Task<ResponseDto?> RestoreCouponAsync(Guid id);
    }
}
