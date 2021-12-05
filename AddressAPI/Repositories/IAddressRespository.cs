using AddressAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressAPI.Repositories
{
    /// <summary>
    /// This interface is used to perform the opration of the database
    /// </summary>
    public interface IAddressRespository
    {
        /// <summary>
        /// Interface for Part 1: General API       
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Address>> Get();
        Task<Address> Get(int id);
        Task<Address> Create(Address address);
        Task Update(Address address);
        Task Delete(int id);

        /// <summary>
        ///    Interface for Part 2: Filters used to filter and search by city, street , zipcode, country ...
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        List<AddressModel> GetAddressByFilter(string search, string sortBy);

        /// <summary>
        /// This part is for findind the distance between two points using google distance matrix api
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
         double GetDistance(string origin, string destination);



    }
}
