using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetAll();

        Task<Categories> GetById(int id);

        Task Update(Categories categories);
        Task Delete(int id);
        Task add(Categories categories);
    }
}
