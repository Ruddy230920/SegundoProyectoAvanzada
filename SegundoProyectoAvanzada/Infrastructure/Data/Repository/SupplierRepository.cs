using Microsoft.EntityFrameworkCore;
using SegundoProyectoAvanzada.Infrastructure.Data;
using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{

    public class SupplierRepository : ISupplierRepository
    {
        private readonly NorthwindDbContexts _context;
        public SupplierRepository(NorthwindDbContexts context)
        {
            _context = context;
        }

        public async Task add(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierID == id);
            _context.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Supplier>> GetALL()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierID == id);
        }

        public async Task Update(Supplier supplier)
        {
            var suppliers = _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierID == supplier.SupplierID);
            await _context.SaveChangesAsync();
        }
    }
}
