using SalesWebMVc.Data;
using SalesWebMVc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVc.Services
{
    public class SellerService
    {

        private readonly SalesWebMVcContext _context;
        public SellerService(SalesWebMVcContext context)
        {
            _context = context;
        }


       public List<Seller> FindAll()
        {
         return   _context.Sellers.ToList();
        }

        public void Insert( Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
