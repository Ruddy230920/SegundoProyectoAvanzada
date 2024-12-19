using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetALL();
        Task<Supplier> GetById(int id);
        Task Update(Supplier supplier);
        Task Delete(int id);
        Task add(Supplier supplier);
    }
}
