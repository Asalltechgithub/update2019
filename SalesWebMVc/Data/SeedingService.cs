using SalesWebMVc.Models;
using SalesWebMVc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVc.Data
{
    public class SeedingService
    {
        private SalesWebMVcContext _context;
        public SeedingService(SalesWebMVcContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() || _context.Sellers.Any() || _context.salesRecords.Any())
            {
                return;
            }
            Department d1 = new Department(1, "Computer");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Allyson Vinicius".ToUpper(), 10.000, new DateTime(1985, 05, 02), d1);
            Seller s2 = new Seller(2, "Vanessa Soares".ToUpper(), 10.000, new DateTime(1981, 06, 07), d3);
            Seller s3 = new Seller(3, "Roberto CArlos".ToUpper(), 5.000, new DateTime(1984, 09, 08), d2);
            Seller s4 = new Seller(4, "Cassia Silva".ToUpper(), 1.000, new DateTime(1988, 03, 09), d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(DateTime.Now.Day), 11.000, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(DateTime.Now.Day), 50.000, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(DateTime.Now.Day), 1.000, SaleStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(DateTime.Now.Day), 100.000, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Sellers.AddRange(s1, s2, s3, s4);
            _context.salesRecords.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();
        
        }
    }
}
