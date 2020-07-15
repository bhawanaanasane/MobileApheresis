using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MobileAheresisAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        [HttpGet("NurseList")]
        public IActionResult NurseList(int id) {
            return Ok(id);
        }
    }
}