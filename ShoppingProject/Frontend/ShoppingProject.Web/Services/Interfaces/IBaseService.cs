using ShoppingProject.Web.Models.Dtos;

namespace ShoppingProject.Web.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto dto);
    }
}
