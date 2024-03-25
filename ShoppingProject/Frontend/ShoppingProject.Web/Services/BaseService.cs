using Newtonsoft.Json;
using ShoppingProject.Web.Models.Dtos;
using ShoppingProject.Web.Services.Interfaces;
using System.Net;
using System.Text;
using static ShoppingProject.Web.Models.Utility.StaticDetails;

namespace ShoppingProject.Web.Services
{
    public class BaseService : IBaseService
    {
        IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto dto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ShoppingProjectAPIClient");

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");

                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(dto.Url);

                if (dto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(dto.Data), Encoding.UTF8, "application/json");
                }

                message.Method = dto.ApiType switch
                {
                    ApiType.GET => HttpMethod.Get,
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get
                };

                var response = await client.SendAsync(message);

                return response.StatusCode switch
                {
                    HttpStatusCode.OK => JsonConvert.DeserializeObject<ResponseDto>(await response.Content.ReadAsStringAsync()),
                    _ => new ResponseDto(null, false, response.StatusCode.ToString())
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto(ex, false, ex.Message);
            }
        }
    }
}
