﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVc.Models;

namespace SalesWebMVc.Data
{
    public class SalesWebMVcContext : DbContext
    {
        public SalesWebMVcContext (DbContextOptions<SalesWebMVcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<SalesRecord> salesRecords { get; set; }

        public DbSet<Seller> Sellers { get; set; }

    }
}