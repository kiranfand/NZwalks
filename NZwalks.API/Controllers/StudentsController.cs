
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    // kiran fand SDK infotech  
    // rushi jagtap 
    // kiran fand SDK infotech
    // swappy amantya technologies
    // https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: https://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "Kiran", "Swappy", "Prash", "Pandu", "Kallu" };

            return Ok(studentNames);
        }
    }
}