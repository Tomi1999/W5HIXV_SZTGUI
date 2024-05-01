using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using W5HIXV_HFT_2023241.Endpoint.Services;
using W5HIXV_HFT_2023241.Logic;
using W5HIXV_HFT_2023241.Models;

namespace w5hixv_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : Controller
    {
        IDriverLogic logic;
        IHubContext<SignalRHub> hub;

        public DriverController(IDriverLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub; 
        }



        // GET: api/<SiteController>
        [HttpGet]
        public IEnumerable<Driver> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<SiteController>/5
        [HttpGet("{id}")]
        public Driver Read(int id)
        {
            return logic.Read(id);

        }

        // POST api/<SiteController>
        [HttpPost]
        public void Create([FromBody] Driver value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("DriverCreated", value);
        }

        // PUT api/<SiteController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Driver value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("DriverUpdated", value);
        }

        // DELETE api/<SiteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("DriverDeleted", value);
        }
    }
}
