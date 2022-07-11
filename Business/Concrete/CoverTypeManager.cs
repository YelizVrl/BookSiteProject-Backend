using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CoverTypeManager : ICoverTypeService
    {
        ICoverTypeDal _coverTypeDal;

        public CoverTypeManager(ICoverTypeDal coverTypeDal)
        {
            _coverTypeDal = coverTypeDal;
        }


        public IDataResult<List<CoverType>> GetAll()
        {
            return new SuccessDataResult<List<CoverType>>(_coverTypeDal.GetAll());
        }
    }
}
