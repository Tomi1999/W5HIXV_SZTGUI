using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W5HIXV_HFT_2023241.Logic;
using W5HIXV_HFT_2023241.Models;

namespace w5hixv_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CarNonController : Controller
    {
        ICarLogic logic;

        public CarNonController(ICarLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Car> CarsOverTW(int weith)
        {
            return this.logic.CarsOverTW(weith);
        }

        [HttpGet]
        public IEnumerable<Car> GetBrands(string brand)
        {
            return this.logic.GetBrands(brand);
        }
    }
}
