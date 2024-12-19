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
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly NorthwindDbContexts _context;
        public CategoriesRepository(NorthwindDbContexts context)
        {
            _context = context;
        }
        public async Task add(Categories categories)
        {
            await _context.Categories.AddAsync(categories);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var categoria = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryID == id);
            _context.Categories.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Categories> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.CategoryID == id);


        }

        public async Task Update(Categories categories)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryID == categories.CategoryID);
            //category.CategoryName=categories.CategoryName;
            //category.Description=categories.Description;
            await _context.SaveChangesAsync();
        }

    }
}
