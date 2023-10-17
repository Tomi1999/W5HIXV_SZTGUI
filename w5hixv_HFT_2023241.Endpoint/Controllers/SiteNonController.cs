using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using W5HIXV_HFT_2023241.Logic;
using W5HIXV_HFT_2023241.Models;

namespace w5hixv_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SiteNonController : Controller
    {
        ISiteLogic logic;

        public SiteNonController(ISiteLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Car> CarsInSite(int id)
        {
            return logic.CarsInSite(id);
        }
        [HttpGet]
        public IEnumerable<Driver> DriverInSite(int id)
        {
            return logic.DriverInSite(id);
        }
    }
}
