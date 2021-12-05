using AddressAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DistanceOfTwoAddressController : ControllerBase
    {
        private readonly IAddressRespository _addressRepository;

        public DistanceOfTwoAddressController(IAddressRespository addressRespository)
        {
            _addressRepository = addressRespository;

        }
        [HttpGet]
        public  IActionResult  GetDistanceOfTwoAddresses(string origin, string desitination)
        {
            try
            {
                var result = _addressRepository.GetDistance(origin, desitination);
                return Ok(result);
            }
            catch
            {

                return BadRequest("we can't able to find the distance. ");
            }
        }

    }
}
