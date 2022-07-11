using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {

        IWriterDal _writerDal;


        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public IDataResult<List<Writer>> GetAll()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll());
        }

        public IDataResult<Writer> GetById(int writerId)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(c => c.WriterId == writerId));
        }

        public IResult Add(Writer writer)
        {
            _writerDal.Add(writer);
            return new SuccessResult();
        }

        public IResult Update(Writer writer)
        {
            _writerDal.Update(writer);
            return new SuccessResult();
        }


        public IResult Delete(Writer writer)
        {
            _writerDal.Delete(writer);
            return new SuccessResult();
        }
    }
}
