using Microsoft.EntityFrameworkCore;
using SegundoProyectoAvanzada.Infrastructure.Data;
using SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly NorthwindDbContexts _context;
        public CustomersRepository(NorthwindDbContexts context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customers>> GetAll()
        {
            return await _context.Customers.ToListAsync();

        }
    }
}
