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

        public List<AddressModel> GetAddressByFilter(string search, string sortBy)
        {
            var allAddresses = _context.Addresses.AsQueryable();
            #region search and filter
            if (!string.IsNullOrEmpty(search))
            {
                allAddresses = allAddresses.Where(
                  aa => aa.City.Contains(search)
                ||aa.Country.Contains(search)
                ||aa.ZipCode.Contains(search)
                || aa.Street.Contains(search)
                ||aa.Id.Equals(search));
               
            }
            #endregion

            #region here is the sorting part
            // default sorting will be by country
            allAddresses = allAddresses.OrderBy(aa => aa.Country);
            if(!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "country_desc": allAddresses = allAddresses.OrderByDescending(aa => aa.Country); break;
                    case "city_asc": allAddresses = allAddresses.OrderBy(aa => aa.City); break;
                    case "city_desc": allAddresses = allAddresses.OrderByDescending(aa => aa.City); break;
                    case "zipCode_asc": allAddresses = allAddresses.OrderBy(aa => aa.ZipCode); break;
                    case "zipCode_desc": allAddresses = allAddresses.OrderByDescending(aa => aa.ZipCode); break;
                    case "street_asc": allAddresses = allAddresses.OrderBy(aa => aa.Street); break;
                    case "street_desc": allAddresses = allAddresses.OrderByDescending(aa => aa.Street); break;
                    case "housenr_desc": allAddresses = allAddresses.OrderBy(aa => aa.HouseNr); break;
                    case "houseNr_desc": allAddresses = allAddresses.OrderByDescending(aa => aa.HouseNr); break;
                    case "id_asc": allAddresses = allAddresses.OrderBy(aa => aa.Id); break;
                    case "id_desc": allAddresses = allAddresses.OrderByDescending(aa => aa.Id); break;


                }

            }

            #endregion

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
