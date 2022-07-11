using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PublishingHouseManager : IPublishingHouseService
    {

        IPublishingHouseDal _publishingHouseDal;


        public PublishingHouseManager(IPublishingHouseDal publishingHouseDal)
        {
            _publishingHouseDal = publishingHouseDal;
        }

        public IDataResult<List<PublishingHouse>> GetAll()
        {
            return new SuccessDataResult<List<PublishingHouse>>(_publishingHouseDal.GetAll());
        }

        public IDataResult<PublishingHouse> GetById(int publishingHouseId)
        {
            return new SuccessDataResult<PublishingHouse>(_publishingHouseDal.Get(c => c.PublishingHouseId == publishingHouseId));
        }


        public IResult Add(PublishingHouse publishingHouse)
        {
            _publishingHouseDal.Add(publishingHouse);
            return new SuccessResult();
        }

        public IResult Update(PublishingHouse publishingHouse)
        {
            _publishingHouseDal.Update(publishingHouse);
            return new SuccessResult();
        }


        public IResult Delete(PublishingHouse publishingHouse)
        {
            _publishingHouseDal.Delete(publishingHouse);
            return new SuccessResult();
        }
    }
}
