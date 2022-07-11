using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BookDetailDto : IDto
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public int WriterId { get; set; }
        public int PublishingHouseId { get; set; }
        public string BookName { get; set; }
        public string CategoryName { get; set; }
        public string WriterName { get; set; }
        public string PublishingHouseName { get; set; }
        public string PageNumber { get; set; }
        public string CoverTypeName { get; set; }
        public string PageTypeName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<string> ImagePath { get; set; }

    }
}
