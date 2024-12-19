using Microsoft.EntityFrameworkCore;
using SegundoProyectoAvanzada.Infrastructure.Data;
using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Data.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly NorthwindDbContexts _context;

        public OrdersRepository(NorthwindDbContexts context)
        {
            _context = context;
        }



        public async Task add(Orders orders)
        {
            if (orders == null)
                throw new ArgumentNullException(nameof(orders), "La orden no puede ser nula.");

            await _context.Orders.AddAsync(orders);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                throw new KeyNotFoundException($"No se encontró una orden con el ID {id}.");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Orders>> GetAll()
        {
            return await _context.Orders
                         .Include(o => o.Customers)
                         .Include(o => o.Employees)
                         .Include(o => o.Shippers)

                         .ToListAsync();
        }

        public async Task<Orders> GetById(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.Employees)
                .Include(o => o.Shippers)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
                throw new KeyNotFoundException($"No se encontró una orden con el ID {id}.");

            return order;
        }

        public async Task Update(Orders orders)
        {
            var existingOrder = await _context.Orders.FindAsync(orders.OrderID);
            if (existingOrder == null)
                throw new KeyNotFoundException($"No se encontró una orden con el ID {orders.OrderID}.");

            // Actualizar los campos necesarios
            existingOrder.CustomerID = orders.CustomerID;
            existingOrder.EmployeeID = orders.EmployeeID;
            existingOrder.OrderDate = orders.OrderDate;
            existingOrder.RequiredDate = orders.RequiredDate;
            existingOrder.ShippedDate = orders.ShippedDate;
            existingOrder.ShipVia = orders.ShipVia;
            existingOrder.Freight = orders.Freight;
            existingOrder.ShipName = orders.ShipName;
            existingOrder.ShipAddress = orders.ShipAddress;
            existingOrder.ShipCity = orders.ShipCity;
            existingOrder.ShipRegion = orders.ShipRegion;
            existingOrder.ShipPostalCode = orders.ShipPostalCode;
            existingOrder.ShipCountry = orders.ShipCountry;

            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();
        }
    }
}
