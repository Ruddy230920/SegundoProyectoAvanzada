using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Services
{
    public interface ICategoriesServices
    {
        Task<IEnumerable<CategoriesDTO>> GetAllAsync();
        Task<CategoriesDTO> GetById(int id);
        Task Update(CategoriesDTO categories);
        Task Delete(CategoriesDTO categories);
        Task add(CategoriesDTO categories);
    }
}
