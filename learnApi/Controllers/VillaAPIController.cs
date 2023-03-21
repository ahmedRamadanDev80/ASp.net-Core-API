using learnApi.Models;
using learnApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas() 
        {
            return new List<VillaDTO> { 
                new VillaDTO { Id = 1, Nmae = "Villa north coast" }, 
                new VillaDTO { Id = 2, Nmae = "Villa red sea" } 
            };
        }
    }
}
