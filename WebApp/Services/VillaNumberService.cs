using WebApp.Models;
using WebApp.Models.Dto;
using WebApp.Services.IServices;
using WebApp_Utility;

namespace WebApp.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;

        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        }

        // ---------- CREATE ----------
        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto,string token)
        {
            return SendAsync<T>(new APIRequest(){ apiType = SD.ApiType.POST, Data = dto, Url = villaUrl + "/api/villaNumberAPI", Token = token });
        }

        // ---------- DELETE ----------
        public Task<T> DeleteAsync<T>(int Num,string token)
        {
            return SendAsync<T>(new APIRequest(){ apiType = SD.ApiType.DELETE, Url = villaUrl + "/api/villaNumberAPI/" + Num , Token = token });
        }

        // ---------- GET ALL ----------
        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest(){ apiType = SD.ApiType.GET, Url = villaUrl + "/api/villaNumberAPI", Token = token });
        }

        // ---------- GET BY ID ----------
        public Task<T> GetAsync<T>(int Num, string token)
        {
            return SendAsync<T>(new APIRequest(){ apiType = SD.ApiType.GET, Url = villaUrl + "/api/villaNumberAPI/" + Num , Token = token });
        }

        // ---------- UPDATE ----------
        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto,string token)
        {
            return SendAsync<T>(new APIRequest(){ apiType = SD.ApiType.PUT, Data = dto, Url = villaUrl + "/api/villaNumberAPI/" + dto.VillaNo,Token=token});
        }
    }
}
