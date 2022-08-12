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
    public class ResortManager : IResortService
    {
        private IResortDal _resortDal;
        public ResortManager(IResortDal resortDal)
        {
            _resortDal = resortDal;
        }
        public void Add(Resort resort)
        {
            _resortDal.Add(resort);
        }

        public void Delete(int resortId)
        {
            _resortDal.Delete(new Resort { Id = resortId });
        }

        public IDataResult<Resort> GetResort(int resortId)
        {
            return new SuccessDataResult<Resort>(_resortDal.Get(p => p.Id == resortId));
        }

        public List<Resort> GetResorts()
        {
            return _resortDal.GetList().ToList();
        }

        public void Update(Resort resort)
        {
            _resortDal.Update(resort);
        }
    }
}
