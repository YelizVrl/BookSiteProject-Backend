using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public int WriterId { get; set; }
        public int PublishingHouseId { get; set; }
        public int CoverTypeId { get; set; }
        public int PageTypeId { get; set; }
        public string BookName { get; set; }
        public string PageNumber { get; set; }
        public short UnitsInStock { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}
