using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CoverType : IEntity
    {
        public int CoverTypeId { get; set; }
        public string CoverTypeName { get; set; }
    }
}
