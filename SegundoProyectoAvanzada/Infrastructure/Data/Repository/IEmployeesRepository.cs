using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employees>> GetAll();
    }
}
