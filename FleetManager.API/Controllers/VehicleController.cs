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
                Model = "Firebird", 
                Make = "Pontiac", 
                ProductionYear = 1986,
                FriendlyName = "KITT"
            },
            new VehicleModel
            {
                Model = "DMC-12", 
                Make = "DeLorean", 
                ProductionYear = 1984,
                FriendlyName = "Time Machine"
            },
            new VehicleModel
            {
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



        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] string value)
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
