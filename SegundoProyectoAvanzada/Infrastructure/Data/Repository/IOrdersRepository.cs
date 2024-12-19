using SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAll();
        Task<Orders> GetById(int id);
        Task Update(Orders orders);
        Task Delete(int id);
        Task add(Orders orders);
    }
}
