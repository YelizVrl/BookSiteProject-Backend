using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWriterService
    {
        IDataResult<List<Writer>> GetAll();
        IDataResult<Writer> GetById(int writerId);
        IResult Add(Writer writer);
        IResult Update(Writer writer);
        IResult Delete(Writer writer);
    }
}
