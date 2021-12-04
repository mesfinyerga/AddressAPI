using AddressAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressAPI.Repositories
{
    public class AddressRepository : IAddressRespository
    {
        private readonly AddressContext _context;

        public AddressRepository(AddressContext context)
        {
            this._context = context;
        }

        public async Task<Address> Create(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task Delete(int id)
        {
            var addressToDelete = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(addressToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> Get()
        {
            return await _context.Addresses.ToListAsync();

        }

        public async Task<Address> Get(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public List<AddressModel> GetAddressByFilter(string search)
        {
            var allAddresses = _context.Addresses.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                allAddresses = allAddresses.Where(
                  aa => aa.City.Contains(search)
                ||aa.Country.Contains(search)
                ||aa.ZipCode.Contains(search)
                || aa.Street.Contains(search)
                ||aa.Id.Equals(search));
               
            }

            var result = allAddresses.Select(aa => new AddressModel {
                City = aa.City, 
                Country = aa.Country,
                HouseNr=aa.HouseNr, 
                Id=aa.Id, 
                Street=aa.Street, 
                ZipCode=aa.ZipCode
                
            });

            return result.ToList();
        }

       
    }
}
