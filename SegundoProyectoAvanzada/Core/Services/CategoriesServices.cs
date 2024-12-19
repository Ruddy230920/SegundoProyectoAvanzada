using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Infrastructure.Data.Repository;
using SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Services
{

    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesServices(ICategoriesRepository categoriesRepository) 
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task add(CategoriesDTO categories)
        {
            var entity = new Categories
            {
                CategoryName = categories.CategoryName,
                Description = categories.Description
            };

            await _categoriesRepository.add(entity);
        }

        public async Task Delete(CategoriesDTO categories)
        {
            var category = await _categoriesRepository.GetById(categories.CategoryID);

            if (category == null)
            {
                throw new KeyNotFoundException($"El producto con ID {categories.CategoryID} no existe.");
            }


            await _categoriesRepository.Delete(categories.CategoryID);
        }

        public async Task<IEnumerable<CategoriesDTO>> GetAllAsync()
        {
            var category = await _categoriesRepository.GetAll();

            return category.Select(categories => new CategoriesDTO
            {
                CategoryID = categories.CategoryID,
                CategoryName = categories.CategoryName,
                Description = categories.Description,
                Picture = categories.Picture,
                
            });
        }

        public async Task<CategoriesDTO> GetById(int id)
        {
            var category = await _categoriesRepository.GetById(id);

            return new CategoriesDTO
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        public async Task Update(CategoriesDTO categories)
        {
            var entity = await _categoriesRepository.GetById(categories.CategoryID);
          
            entity.CategoryName =categories.CategoryName;
            entity.Description = categories.Description;

            await _categoriesRepository.Update(entity);
        }
    }
}
