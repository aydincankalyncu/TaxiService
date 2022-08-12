using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public void Add(Address address)
        {
            _addressDal.Add(address);
        }

        public void Delete(int addressId)
        {
            _addressDal.Delete(new Address { Id = addressId });
        }

        public IDataResult<Address> GetAddressById(int addressId)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(p => p.Id == addressId));
        }

        public List<Address> GetAddressList()
        {
            return _addressDal.GetList().ToList();
        }

        public void Update(Address address)
        {
            _addressDal.Update(address);
        }
    }
}
