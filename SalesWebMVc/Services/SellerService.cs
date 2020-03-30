using SalesWebMVc.Data;
using SalesWebMVc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVc.Services.Exceptions;

namespace SalesWebMVc.Services
{
    public class SellerService
    {

        private readonly SalesWebMVcContext _context;
        public SellerService(SalesWebMVcContext context)
        {
            _context = context;
        }


        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Seller> FindByIdAsync(int Id)
        {
            return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = _context.Sellers.Find(Id);
                _context.Sellers.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e )
            {
                throw new IntegrityException(e.Message);
            }


        }
        public async Task UpdateAsync(Seller obj)
        {
            var HasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!HasAny)
            {
                throw new NotFoundException("Id not found ");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
