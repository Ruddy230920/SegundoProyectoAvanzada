using Microsoft.EntityFrameworkCore.Infrastructure;
using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Models;
using Dm = SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Services.MappingFolder
{
    public class Mapping
    {
        public static OrdersDTO OrdersToDTO(Orders orders)
        {
            var order = new OrdersDTO
            {
                CustomerName = orders.Customers.CompanyName ?? string.Empty,
                CustomerID = orders.CustomerID,
                EmployeeID = orders.EmployeeID ?? 0,
                EmployeeName = orders.Employees?.FirstName ?? string.Empty,             
                OrderDate = orders.OrderDate ?? DateTime.MinValue,  
                RequiredDate = orders.RequiredDate ?? DateTime.MinValue, 
                ShippedDate = orders.ShippedDate ?? DateTime.MinValue, 
                //ShipVia = orders.ShipVia ?? 0, 
                Freight = orders.Freight ?? 0, 
                ShipName = orders.ShipName ?? string.Empty,
                ShipAddress = orders.ShipAddress ?? string.Empty,
                ShipCity = orders.ShipCity ?? string.Empty,
                ShipRegion = orders.ShipRegion ?? string.Empty,
                ShipPostalCode = orders.ShipPostalCode ?? string.Empty,
                ShipCountry = orders.ShipCountry ?? string.Empty
            };
            return order;
        }
        public static ProductsDTO ProductsToDTO(Products products)
        {
            return new ProductsDTO
            {
                ProductID = products.ProductID,
                ProductName = products.ProductName,
                CategoryName = products.Category?.CategoryName ?? string.Empty,
                CompanyName = products.Supplier?.CompanyName ?? string.Empty,
                QuantityPerUnit = products.QuantityPerUnit,
                UnitPrice = products.UnitPrice,
                UnitsInStock = products.UnitsInStock,
                UnitsOnOrder = products.UnitsOnOrder,
                Discontinued = products.Discontinued,
                CategoryID = products.CategoryID,
                SupplierID = products.SupplierID,
            };


        }
        public static Products DtoToProducts(ProductsDTO productsDTO)
        {
            return new Products
            {
                ProductID = productsDTO.ProductID,
                ProductName = productsDTO.ProductName,
                QuantityPerUnit = productsDTO.QuantityPerUnit,
                UnitPrice = productsDTO.UnitPrice,
                UnitsInStock = productsDTO.UnitsInStock,
                UnitsOnOrder = productsDTO.UnitsOnOrder,
                Discontinued = productsDTO.Discontinued,
                CategoryID = productsDTO.CategoryID,
                SupplierID = productsDTO.SupplierID,
            };


        }
        


        public static CategoriesDTO CategoriesToDTO(Categories categories)
        {
            return new CategoriesDTO
            {
                CategoryID = categories.CategoryID,
                CategoryName = categories.CategoryName,
                Description = categories.Description,
                Picture = categories.Picture,

            };
        }
        public static SupplierDTO SupplierToDTO(Supplier supplier)
        {
            return new SupplierDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country,
                Phone = supplier.Phone,

            };
        }
    }
}
