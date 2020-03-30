using Microsoft.EntityFrameworkCore;
using SalesWebMVc.Data;
using SalesWebMVc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVc.Services
{
    public class SalesRecordsService
    {
        private readonly SalesWebMVcContext _context;
        public SalesRecordsService(SalesWebMVcContext context)
        {
            _context = context;
        }

        public async Task< List<SalesRecord> >FindByDate(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.salesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
          return await result
                .Include(x=> x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x=> x.Date)
                .ToListAsync();
        }

    }
}
