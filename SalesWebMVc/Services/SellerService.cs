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
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById(int Id)
        {
            return _context.Sellers.FirstOrDefault(x => x.Id == Id);
        }
        public void Remove (int Id)
        {
            var obj = _context.Sellers.Find(Id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }
    }
}
