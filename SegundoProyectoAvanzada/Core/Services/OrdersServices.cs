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
    public class OrdersServices : IOrdersServices
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersServices(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task add(OrdersDTO orders)
        {
            var order = new Orders
            {
                CustomerID = orders.CustomerID,            
                EmployeeID = orders.EmployeeID,
                OrderDate = orders.OrderDate,
                RequiredDate = orders.RequiredDate,
                ShippedDate = orders.ShippedDate,
                Freight=orders.Freight,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipPostalCode = orders.ShipPostalCode,
                ShipRegion= orders.ShipRegion,
                ShipCountry = orders.ShipCountry
            };

            await _ordersRepository.add(order);
        }

        public async Task Delete(int id)
        {
            var order = await _ordersRepository.GetById(id);
            if (order == null)
            {
                throw new KeyNotFoundException($"No se encontró una orden con el ID {id}.");
            }

            await _ordersRepository.Delete(id);
        }

        public async Task<IEnumerable<OrdersDTO>> GetAllAsync()
        {
            var orders = await _ordersRepository.GetAll();

            return orders.Select(order => new OrdersDTO
            {
                OrderID = order.OrderID.Value,
                CustomerID = order.CustomerID,
                CustomerName =order.Customers.ContactName,
                EmployeeID = order.EmployeeID.Value,
                EmployeeName =order.Employees.FirstName,
                ShipVia = order.ShipVia.Value,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion=order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            });
        }

        public async Task<OrdersDTO> GetById(int id)
        {
            var order = await _ordersRepository.GetById(id);

            return new OrdersDTO
            {
                OrderID = order.OrderID.Value,
                CustomerID = order.CustomerID,
                EmployeeID = order.EmployeeID.Value,
                ShipVia = order.ShipVia.Value,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            };
        }

        public async Task Update(OrdersDTO orders)
        {
            var order = await _ordersRepository.GetById(orders.OrderID);

            order.CustomerID = orders.CustomerID;
            order.EmployeeID = orders.EmployeeID;
            order.OrderDate = orders.OrderDate;
            order.RequiredDate = orders.RequiredDate;
            order.ShippedDate = orders.ShippedDate;
            order.ShipName = orders.ShipName;
            order.ShipAddress = orders.ShipAddress;
            order.ShipCity = orders.ShipCity;
            order.ShipPostalCode = orders.ShipPostalCode;
            order.ShipCountry = orders.ShipCountry;

            await _ordersRepository.Update(order);
        }
    }
}
