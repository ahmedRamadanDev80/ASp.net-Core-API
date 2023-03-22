using learnApi.Data;
using learnApi.Models;
using learnApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace learnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas() 
        {
            return Ok(VillaStore.villaList);
        }
        [HttpGet("{id:int}")]
        public ActionResult<VillaDTO> GetVilla(int id) 
        {
            if (id == 0) { return BadRequest(); }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null) { return NotFound(); }
            return Ok(villa);
        }
    }
}
