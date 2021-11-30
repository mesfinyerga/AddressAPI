using AddressAPI.Models;
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
    public class AddressController : ControllerBase
    {
        private readonly IAddressRespository _addressRepository;

        public AddressController(IAddressRespository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _addressRepository.Get();
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<Address>> GetAddresses(int id)
        {
            return await _addressRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddresses([FromBody] Address address)
        {
            var newAddress = await _addressRepository.Create(address);
            return CreatedAtAction(nameof(GetAddresses), new { id = newAddress.Id }, newAddress);
        }

        [HttpPut]
        public async Task<ActionResult<Address>> PutAddresses(int id,[FromBody] Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
              
            }
            await _addressRepository.Create(address);
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var addressToDelete = await _addressRepository.Get(id);
            if (addressToDelete == null)
                return NotFound();

            await _addressRepository.Delete(addressToDelete.Id);
            return NoContent();
        }
    }
}

