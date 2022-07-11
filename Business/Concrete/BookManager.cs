using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {

        IBookDal _BookDal;

        public BookManager(IBookDal bookDal)
        {
            _BookDal = bookDal;
        }



        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BookValidator))]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Add(Book book)
        {
            _BookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Book book)
        {
            throw new NotImplementedException();
        }



        public IResult Delete(Book book)
        {
            _BookDal.Delete(book);
            return new SuccessResult();
        }


        [CacheAspect]
        public IDataResult<List<Book>> GetAll()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Book>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Book>>(_BookDal.GetAll(), Messages.BooksListed);
        }



        public IDataResult<List<BookDetailDto>> GetBookDetails()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_BookDal.GetBookDetails());
        }


        public IDataResult<List<BookDetailDto>> GetBookDetailsByBookId(int bookId)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_BookDal.GetBookDetails(c => c.BookId == bookId));
        }


        public IDataResult<List<BookDetailDto>> GetBooksByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_BookDal.GetBookDetails(p => p.CategoryId == categoryId));
        }

        public IDataResult<List<BookDetailDto>> GetBooksByPublishingHouseId(int publishingHouseId)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_BookDal.GetBookDetails(p => p.PublishingHouseId == publishingHouseId));
        }

        public IDataResult<List<BookDetailDto>> GetBooksByWriterId(int writerId)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_BookDal.GetBookDetails(p => p.WriterId == writerId));
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_BookDal.Get(p => p.BookId == bookId));
        }


        [CacheRemoveAspect("IBookService.Get")]
        public IResult Update(Book book)
        {
            _BookDal.Update(book);
            return new SuccessResult();
        }

        //fhgfh
    }
}
