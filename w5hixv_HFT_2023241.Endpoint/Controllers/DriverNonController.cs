using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W5HIXV_HFT_2023241.Logic;
using W5HIXV_HFT_2023241.Models;

namespace w5hixv_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DriverNonController : Controller
    {
        IDriverLogic logic;

        public DriverNonController(IDriverLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Driver> DriversOverValue(int value)
        {
            return this.logic.DriversOverValue(value);
        }
    }
}
