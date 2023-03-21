using learnApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas() 
        {
            return new List<Villa> { 
                new Villa { Id = 1, Nmae = "Villa north coast" }, 
                new Villa { Id = 2, Nmae = "Villa red sea" } 
            };
        }
    }
}
