﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Writer : IEntity
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
    }
}
