﻿using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookImageDal : EfEntityRepositoryBase<BookImage, BookSiteDatabaseContext>, IBookImageDal
    {
    }
}
