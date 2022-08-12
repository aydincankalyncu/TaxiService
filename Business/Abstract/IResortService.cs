using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IResortService
    {
        void Add(Resort resort);
        void Delete(int resortId);
        void Update(Resort resort);
        List<Resort> GetResorts();
        IDataResult<Resort> GetResort(int resortId);
    }
}
