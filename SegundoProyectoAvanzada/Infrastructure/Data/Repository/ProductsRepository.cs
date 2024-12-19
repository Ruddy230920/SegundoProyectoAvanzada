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
    public class ProductsRepository : IProductsRepository
    {
        private readonly NorthwindDbContexts _context;
        public ProductsRepository(NorthwindDbContexts context)
        {
            _context = context;
        }
        public async Task add(Products Products)
        {
            var categoryExists = await _context.Categories.AnyAsync(c => c.CategoryID == Products.CategoryID);
            if (!categoryExists)
                throw new Exception($"La categoría con ID {Products.CategoryID} no existe.");

            // Verificar si el proveedor existe
            var supplierExists = await _context.Suppliers.AnyAsync(s => s.SupplierID == Products.SupplierID);
            if (!supplierExists)
                throw new Exception($"El proveedor con ID {Products.SupplierID} no existe.");

            // Agregar el producto a la base de datos
            await _context.Products.AddAsync(Products);
            await _context.SaveChangesAsync();

            //await _context.Products.AddAsync(Products);
            // await _context.SaveChangesAsync();
        }

        public async Task Delete(Products products)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == products.ProductID);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<Products>> GetAllProducts()
        {

            return await _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToListAsync();
        }

        public async Task<Products> GetProductsById(int ProductId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductID == ProductId);
        }

        public async Task Update(Products Products)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == Products.ProductID);
            await _context.SaveChangesAsync();
        }
    }

}

