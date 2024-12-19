using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Services
{
    public interface ISuppliersServices
    {
        Task<IEnumerable<SupplierDTO>> GetAllAsync();
        Task<SupplierDTO> GetById(int id);
        Task Update(SupplierDTO Suppliers);
        Task Delete(int id);
        Task add(SupplierDTO Suppliers);
    }
}
