using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, BookSiteDatabaseContext>, IBookDal
    {

        public List<BookDetailDto> GetBookDetails(Expression<Func<BookDetailDto, bool>> filter = null)
        {
            using (BookSiteDatabaseContext context = new BookSiteDatabaseContext())
            {
                var result = from b in context.Books
                             join c in context.Categories
                             on b.CategoryId equals c.CategoryId
                             join w in context.Writers
                             on b.WriterId equals w.WriterId
                             join ph in context.PublishingHouses
                             on b.PublishingHouseId equals ph.PublishingHouseId
                             join ct in context.CoverTypes
                             on b.CoverTypeId equals ct.CoverTypeId
                             join pt in context.PageTypes
                             on b.PageTypeId equals pt.PageTypeId

                             select new BookDetailDto
                             {
                                 BookId = b.BookId,
                                 CategoryId = c.CategoryId,
                                 WriterId = w.WriterId,
                                 PublishingHouseId = ph.PublishingHouseId,
                                 BookName = b.BookName,
                                 CategoryName = c.CategoryName,
                                 WriterName = w.WriterName,
                                 PublishingHouseName = ph.PublishingHouseName,
                                 PageNumber = b.PageNumber,
                                 CoverTypeName = ct.CoverTypeName,
                                 PageTypeName = pt.PageTypeName,
                                 Price = b.Price,
                                 Description = b.Description,
                                 ImagePath = (from m in context.BookImages where m.BookId == b.BookId select m.ImagePath).ToList()
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
