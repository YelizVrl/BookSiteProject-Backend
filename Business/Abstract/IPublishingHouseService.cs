using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPublishingHouseService
    {
        IDataResult<List<PublishingHouse>> GetAll();
        IDataResult<PublishingHouse> GetById(int publishingHouseId);
        IResult Add(PublishingHouse publishingHouse);
        IResult Update(PublishingHouse publishingHouse);
        IResult Delete(PublishingHouse publishingHouse);
    }
}
