﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVc.Services.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string message):base(message)
        {
           
        }
    }
}
