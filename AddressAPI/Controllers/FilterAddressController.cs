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
    public class FilterAddressController : ControllerBase
    {
        private readonly IAddressRespository _addressRepository;

        public FilterAddressController(IAddressRespository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        [HttpGet]
        public IActionResult GetAllAddresses(string search, string sortBy)
        {
            try
            {
                var result = _addressRepository.GetAddressByFilter(search,  sortBy);
                return Ok(result);
            }
            catch
            {

                return BadRequest("we can't find the search address. ");
            }
        }
    }
}
