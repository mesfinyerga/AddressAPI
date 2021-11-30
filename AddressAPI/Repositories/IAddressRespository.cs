using AddressAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressAPI.Repositories
{
    /// <summary>
    /// This interface is used to operform opration of the database
    /// </summary>
    public interface IAddressRespository
    {
        /// <summary>
        /// Interface for Part 1: General API       Part 2: Filters
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Address>> Get();
        Task<Address> Get(int id);
        Task<Address> Create(Address address);
        Task Update(Address address);
        Task Delete(int id);

        /// <summary>
        ///    Interface for Part 2: Filters
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Address> FilterAddressById(int id);

    }
}
