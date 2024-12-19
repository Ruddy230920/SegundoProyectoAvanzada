using SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Services
{
    public interface IOrdersServices
    {
        Task<IEnumerable<OrdersDTO>> GetAllAsync();
        Task<OrdersDTO> GetById(int id);
        Task Update(OrdersDTO orders);
        Task Delete(int id);
        Task add(OrdersDTO orders);
    }
}
