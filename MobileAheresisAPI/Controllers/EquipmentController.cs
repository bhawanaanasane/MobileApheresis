using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Services.Equipments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MobileAheresisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        #region Fields
        private readonly IEquipmentServices _equipmentsServices;
        #endregion

        #region CTOR
        public EquipmentController(
            IEquipmentServices EquipmentServices)
        {
            this._equipmentsServices = EquipmentServices;
        }
        #endregion
        // GET: api/Equipment
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Equipment/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Equipment
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Equipment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
