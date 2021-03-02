using FleetManager.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        //
        // XXX this is a useful trick in other experiments!
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

        // TODO
        // review notes on controller return types and when to use each one
        // eg. Task, ActionResult etc
        // GET: api/<VehicleController>
        [HttpGet]
        public IEnumerable<VehicleModel> GetAll()
        {
            //return new string[] { "value1", "value2" };
            return _vehiclesDatabase;
        }
        
        // GET api/<VehicleController>/2
        // TODO
        // refactor this to represent each car as a Guid and then see what 
        // {id:guid} versus {id:string} does
        //
        // with id:guid as path of https://localhost:5001/api/Vehicle/100
        // does not find the car
        [HttpGet("{id}")]
        // another way is [Route("api/[Controller]/{name}")] then can
        // do api/VehicleController/Kitt
        public ObjectResult GetVehicle(int id)
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
                //return NotFound(new {error = $"Vehicle not found with Id {id}"});
                // better to do this...
                // new MissingCarModel("reason")
                return NotFound(new MissingVehicle($"Vehicle not found with Id {id}"));
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

        // TODO
        // see how piotr did it in his solution
        // https://github.com/PioterB/NetCoreWebApi20210218
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
                // this does not work because i am over-writing the reference, not the value...
                // cf. over-writing an address label of evenlope, rather than contents of envelope
                //vehicle = updates;

                vehicle.Make = updates.Make;
                vehicle.Model = updates.Model;
                vehicle.FriendlyName = updates.FriendlyName;
                vehicle.Mileage = updates.Mileage;

                // TODO
                // use this return which Piotr is doing
                return CreatedAtAction(nameof(Update), new { id = id }, updates);

                //return Ok();
            }
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int removed = _vehiclesDatabase.RemoveAll(v => v.Id == id);

            if (removed == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }

    // TODO
    // this probably belongs in Models top-level dir
    public class MissingVehicle
    {
        public MissingVehicle(string reason)
        {
            Error = reason + " [from model]";
        }

        public string Error { get; set; }
    }
}
