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
    public interface IProductsServices
    {
        Task<IEnumerable<ProductsDTO>> GetAllProductsAsync();
        Task<ProductsDTO> GetProductsByIdAsync(int ProductsId);
        Task Update(ProductsDTO Products);
        Task Delete(ProductsDTO products);
        Task add(ProductsDTO Products);
    }
}
