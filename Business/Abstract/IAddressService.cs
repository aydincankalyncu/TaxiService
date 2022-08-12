using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAddressService
    {
        void Add(Address address);
        void Update(Address address);
        void Delete(int addressId);
        IDataResult<Address> GetAddressById(int addressId);
        List<Address> GetAddressList();
    }
}
