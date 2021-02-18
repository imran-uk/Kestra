using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManager.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// created via Add -> Item -> controller, -> webapi controller with read/write actions

// TODO can I replace return types with Action/Task?

namespace FleetManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        // lets create a manual database of vehicles as a private var
        // useful to do this when you have no actual database
        private List<VehicleModel> _vehiclesDatabase = new List<VehicleModel>
        {
            new VehicleModel
            {
                Id = 100,
                Model = "Firebird", 
                Make = "Pontiac", 
                ProductionYear = 1986,
                FriendlyName = "KITT"
            },
            new VehicleModel
            {
                Id = 200,
                Model = "DMC-12", 
                Make = "DeLorean", 
                ProductionYear = 1984,
                FriendlyName = "Time Machine"
            },
            new VehicleModel
            {
                Id = 300,
                Model = "Civic", 
                Make = "Honda", 
                ProductionYear = 2007,
                FriendlyName = "Rhonda"
            }
        };


        // GET: api/<VehicleController>
        [HttpGet]
        public IEnumerable<VehicleModel> Get()
        {
            //return new string[] { "value1", "value2" };
            return _vehiclesDatabase;
        }



        // GET api/<VehicleController>/2
        [HttpGet("{id}")]
        // another way is [Route("api/[Controller]/{name}")] then can
        // do api/VehcileController/Kitt
        public ActionResult<VehicleModel> Get(int id)
        {
            VehicleModel vehicle = _vehiclesDatabase.SingleOrDefault(v => v.Id == id);

            if(vehicle == null)
            {
                return NotFound($"Vehicle not found with Id: {id}");
                /* HOWTO
                 *
                 * { "error": "Vehicle not found with Id: 9000" }
                 *
                 */
                //return NotFound(Json("Vehicle not found with Id", id));
            }
            else
            {
                return Ok(vehicle);
            }
        }
        
        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] VehicleModel vehicle)
        {
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
