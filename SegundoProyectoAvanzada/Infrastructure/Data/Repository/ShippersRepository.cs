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
    public class ShippersRepository : IShippersRepository
    {
        private readonly NorthwindDbContexts _context;
        public ShippersRepository(NorthwindDbContexts context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Shippers>> GetAll()
        {
            return await _context.Shippers.ToListAsync();
        }
    }
}
