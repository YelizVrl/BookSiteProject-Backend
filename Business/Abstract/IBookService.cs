using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<List<BookDetailDto>> GetBooksByCategoryId(int categoryId);
        IDataResult<List<BookDetailDto>> GetBooksByWriterId(int writerId);
        IDataResult<List<BookDetailDto>> GetBooksByPublishingHouseId(int publishingHouseId);
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
        IDataResult<List<BookDetailDto>> GetBookDetails();
        IDataResult<List<BookDetailDto>> GetBookDetailsByBookId(int bookId);
        IDataResult<Book> GetById(int bookId);

        IResult AddTransactionalTest(Book book);
    }
}
