using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Controllers
{
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbcontext dbContext;
        public RegionsController(NZWalksDbcontext dbContext)
        {
            this.dbContext = dbContext;
                
        }
        // Get ALL REGIONS
        // GET : https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();
           
            return Ok(regions);
        }
        // GET SINGLE REGION or GET Region by ID
        // GET : https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {

            // var region = dbContext.Regions.Find(id);

            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }
            return Ok(region); 
        }
    }
}
