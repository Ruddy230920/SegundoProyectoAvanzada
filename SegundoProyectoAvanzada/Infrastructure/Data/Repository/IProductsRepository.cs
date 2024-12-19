using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductsById(int ProductId);
        Task Update(Products Products);
        Task Delete(Products products);
        Task add(Products Products);
    }
}
