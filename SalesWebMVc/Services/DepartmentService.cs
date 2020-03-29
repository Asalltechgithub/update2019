﻿using SalesWebMVc.Data;
using SalesWebMVc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVcContext _context;
        public DepartmentService(SalesWebMVcContext context)
        {
            _context = context;
        }


        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x=>x.Name).ToList();
        }



    }
}
