using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        //
        // static is important to make variable persist to class
        // between requests
        private static List<VehicleModel> _vehiclesDatabase = new List<VehicleModel>
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
        public IEnumerable<VehicleModel> GetAll()
        {
            //return new string[] { "value1", "value2" };
            return _vehiclesDatabase;
        }



        // GET api/<VehicleController>/2
        [HttpGet("{id}")]
        // another way is [Route("api/[Controller]/{name}")] then can
        // do api/VehcileController/Kitt
        public IActionResult GetVehicle(int id)
        {
            VehicleModel vehicle = _vehiclesDatabase.SingleOrDefault(v => v.Id == id);

            if(vehicle == null)
            {
                //return NotFound($"Vehicle not found with Id: {id}");
                /* HOWTO
                 *
                 * { "error": "Vehicle not found with Id: 9000" }
                 *
                 */
                return NotFound(new {error = $"Vehicle not found with Id {id}"});
                // better to do this...
                // new MissingCarModel("reason")
            }
            else
            {
                return Ok(vehicle);
            }
        }
        
        // POST api/<VehicleController>
        [HttpPost]
        //public IEnumerable<VehicleModel> Post([FromBody] VehicleModel vehicle)
        public IActionResult Create([FromBody] VehicleModel vehicle)
        {
            _vehiclesDatabase.Add(vehicle);
            return Ok();

            //return CreatedAtAction(nameof(Post), vehicle);
            //return _vehiclesDatabase;
        }

        // PUT api/<VehicleController>/400
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] VehicleModel updates)
        {
            // Overwrite from body
            VehicleModel vehicle = _vehiclesDatabase.SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound(new {error = $"Vehicle not found with Id {id}"});
            }
            else
            {
                // HOWTO
                // why can't I do vehicle = model
                vehicle.Make = updates.Make;
                vehicle.Model = updates.Model;
                vehicle.FriendlyName = updates.FriendlyName;

                return Ok();
            }
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _vehiclesDatabase.RemoveAll(v => v.Id == id);

            return Ok();
        }
    }
}
