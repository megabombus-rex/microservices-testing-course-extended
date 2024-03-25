using static ShoppingProject.Web.Models.Utility.StaticDetails;

namespace ShoppingProject.Web.Models.Dtos
{
    public record RequestDto(string Url, object? Data, string AccessToken, ApiType ApiType = ApiType.GET);
}
