using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationSearchController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<LocationModel> Get([FromQuery] LocationSearchModel locationSearch = null)
        {
            ILocationSearchRepository locationSearchRepo = new LocationSearchRepository();
            return locationSearchRepo.Get(locationSearch);
        }
    }
}