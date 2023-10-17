using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using W5HIXV_HFT_2023241.Logic;
using W5HIXV_HFT_2023241.Models;

namespace w5hixv_HFT_2023241.Endpoint.Controllers
{
    public class CarController : Controller
    {
        ICarLogic logic;

        public CarController(ICarLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<SiteController>
        [HttpGet]
        public IEnumerable<Car> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<SiteController>/5
        [HttpGet("{id}")]
        public Car Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<SiteController>
        [HttpPost]
        public void Create([FromBody] Car value)
        {
            this.logic.Create(value);
        }

        // PUT api/<SiteController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Car value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<SiteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
