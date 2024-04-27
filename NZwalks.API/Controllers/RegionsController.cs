using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.DTO;

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
            // get data from db - domain models
            var regionsDomain = dbContext.Regions.ToList();

            // map domain models to DTO
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                RegionDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    regionImageUrl = regionDomain.regionImageUrl

                });
            }



            // Return DTOs
            return Ok(regionsDto);
        }
        // GET SINGLE REGION or GET Region by ID
        // GET : https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {

            // var region = dbContext.Regions.Find(id);
            // get region domain model from db
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Convert domain model to region dto

            var regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                regionImageUrl = regionDomain.regionImageUrl
            };
            // return dto back to client
            return Ok(regionDto); 
        }

    }
}
