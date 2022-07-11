using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PageTypeManager :IPageTypeService
    {
        IPageTypeDal _pageTypeDal;


        public PageTypeManager(IPageTypeDal pageTypeDal)
        {
            _pageTypeDal = pageTypeDal;
        }

        public IDataResult<List<PageType>> GetAll()
        {

            return new SuccessDataResult<List<PageType>>(_pageTypeDal.GetAll());

        }
    }
}
