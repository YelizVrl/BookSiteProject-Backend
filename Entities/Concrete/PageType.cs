using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PageType : IEntity
    {
        public int PageTypeId { get; set; }
        public string PageTypeName { get; set; }
    }
}
