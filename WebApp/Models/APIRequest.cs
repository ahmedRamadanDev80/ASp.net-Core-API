using Microsoft.AspNetCore.Mvc;
using static WebApp_Utility.SD;

namespace WebApp.Models
{
    public class APIRequest
    {
        public ApiType apiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
