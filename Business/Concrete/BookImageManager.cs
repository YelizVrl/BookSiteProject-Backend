using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        IBookImageDal _bookImageDal;
        IFileHelper _fileHelper;

        public BookImageManager(IBookImageDal bookImageDal, IFileHelper fileHelper)
        {
            _bookImageDal = bookImageDal;
            _fileHelper = fileHelper;

        }

        public IResult Add(IFormFile file, BookImage bookImage)
        {
            IResult result = BusinessRules.Run(CheckIfBookImageLimitExceded(bookImage.BookId));
            if (result != null)
            {
                return result;
            }
            bookImage.ImagePath = _fileHelper.Upload(file, PathConstant.ImagesPath).Message;
            bookImage.Date = DateTime.Now;
            _bookImageDal.Add(bookImage);
            return new SuccessResult();
        }

        public IResult Delete(BookImage bookImage)
        {
            _fileHelper.Delete(PathConstant.ImagesPath + bookImage.ImagePath);
            _bookImageDal.Delete(bookImage);
            return new SuccessResult();
        }

        public IDataResult<List<BookImage>> GetAll()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll());
        }

        public IDataResult<List<BookImage>> GetByBookId(int bookId)
        {
            var result = BusinessRules.Run(CheckBookImageExists(bookId));
            if (result != null)
            {
                return new ErrorDataResult<List<BookImage>>(GetDefaultImage(bookId).Data);
            }
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll(i => i.BookId == bookId));
        }

        public IDataResult<BookImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(i => i.BookImageId == imageId));
        }

        public IResult Update(IFormFile file, BookImage bookImage)
        {
            bookImage.ImagePath = _fileHelper.Update(file, PathConstant.ImagesPath + bookImage.ImagePath, PathConstant.ImagesPath).Message;
            _bookImageDal.Update(bookImage);
            return new SuccessResult();
        }

        private IResult CheckIfBookImageLimitExceded(int bookId)
        {
            var result = _bookImageDal.GetAll(i => i.BookId == bookId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckBookImageExists(int bookId)
        {
            var result = _bookImageDal.GetAll(i => i.BookId == bookId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IDataResult<List<BookImage>> GetDefaultImage(int bookId)
        {
            List<BookImage> bookImage = new List<BookImage>();
            bookImage.Add(new BookImage { BookId = bookId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<BookImage>>(bookImage);
        }
    }
}
