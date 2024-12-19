using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Infrastructure.Data.Repository;
using SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services.DTO;
using SegundoProyectoAvanzada.Services.MappingFolder;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsServices(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        //public async Task add(ProductsDTO Products)
        //{

        //}
        public async Task add(ProductsDTO Products)
        {
            var entity = Mapping.DtoToProducts(Products);

            await _productsRepository.add(entity);

        }



        public async Task Delete(ProductsDTO products)
        {
            var product = await _productsRepository.GetProductsById(products.ProductID);

            if (product == null)
            {
                throw new KeyNotFoundException($"El producto con ID {products.ProductID} no existe.");
            }


            await _productsRepository.Delete(product);
        }


  



        public async Task Update(ProductsDTO Products)
        {
            var product = await _productsRepository.GetProductsById(Products.ProductID);


            product.ProductName = Products.ProductName;
            //product.SupplierID = Products.SupplierID;
            //product.CategoryID = Products.CategoryID;
            product.QuantityPerUnit = Products.QuantityPerUnit;
            product.UnitPrice = Products.UnitPrice;
            product.UnitsInStock = Products.UnitsInStock;
            product.UnitsOnOrder = Products.UnitsOnOrder;
            product.Discontinued = Products.Discontinued;

            await _productsRepository.Update(product);
        }

        public async Task<IEnumerable<ProductsDTO>> GetAllProductsAsync()
        {
            var product0 = await _productsRepository.GetAllProducts();

            if (product0 == null || !product0.Any())
            {
                return Enumerable.Empty<ProductsDTO>();
            }
            return product0.Select(product => Mapping.ProductsToDTO(product));
        }

        public async Task<ProductsDTO>GetProductsByIdAsync(int ProductsId)
        {
            var product = await _productsRepository.GetProductsById(ProductsId);

            return Mapping.ProductsToDTO(product);
        }

        

       
    }
}

