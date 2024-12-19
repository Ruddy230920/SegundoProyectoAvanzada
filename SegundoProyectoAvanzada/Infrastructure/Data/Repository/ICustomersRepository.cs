using SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customers>> GetAll();
    }
}
