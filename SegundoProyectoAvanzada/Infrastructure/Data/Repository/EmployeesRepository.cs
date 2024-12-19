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
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly NorthwindDbContexts _context;
        public EmployeesRepository(NorthwindDbContexts context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employees>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
