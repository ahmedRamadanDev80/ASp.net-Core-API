using WebApp.Models;
using WebApp.Models.Dto;
using WebApp.Services.IServices;
using WebApp_Utility;

namespace WebApp.Services
{
    public class VillaService : BaseService, IVillaService
    {

        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        // ---------- CREATE ----------
        public Task<T> CreateAsync<T>(VillaCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest() {apiType = SD.ApiType.POST,Data =dto,Url=villaUrl+ "/api/v1/villaAPI", Token = token });
        }

        // ---------- DELETE ----------
        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest() { apiType = SD.ApiType.DELETE, Url = villaUrl + "/api/v1/villaAPI/" + id, Token = token });
        }

        // ---------- GET ALL ----------
        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest() { apiType = SD.ApiType.GET, Url = villaUrl + "/api/v1/villaAPI", Token = token });
        }
        // ---------- GET BY ID ----------
        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest() { apiType = SD.ApiType.GET, Url = villaUrl + "/api/v1/villaAPI/" + id , Token = token });
        }

        // ---------- UPDATE ----------
        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest() { apiType = SD.ApiType.PUT, Data = dto, Url = villaUrl + "/api/v1/villaAPI/" + dto.Id , Token = token });
        }
    }
}
