using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Infrastructure.Data.Repository;
using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Services
{
    public class SuppliersServices : ISuppliersServices
    {
        private readonly ISupplierRepository _supplierRepository;
        public SuppliersServices(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task add(SupplierDTO Suppliers)
        {
            var supplier = new Supplier
            {
                CompanyName = Suppliers.CompanyName,
                ContactName = Suppliers.ContactName,
                ContactTitle = Suppliers.ContactTitle,
                Address = Suppliers.Address,
                City = Suppliers.City,
                Country = Suppliers.Country,
                Phone = Suppliers.Phone,
            };

            await _supplierRepository.add(supplier);
        }

        public async Task Delete(int id)
        {
            
            var supplier = await _supplierRepository.GetById(id);

           
            if (supplier == null)
            {
                throw new Exception($"No se encontró un proveedor con el ID {id}.");
            }

    
            await _supplierRepository.Delete(supplier.SupplierID);
        }

        public async Task<IEnumerable<SupplierDTO>> GetAllAsync()
        {
            var suppliers = await _supplierRepository.GetALL();

            return suppliers.Select(supplier => new SupplierDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country,
                Phone = supplier.Phone
            });
        }

        public async Task<SupplierDTO> GetById(int id)
        {
            var supplier = await _supplierRepository.GetById(id);

            return new SupplierDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country,
                Phone = supplier.Phone
            };
        }

        public  async Task Update(SupplierDTO Suppliers)
        {
            var supplier = await _supplierRepository.GetById(Suppliers.SupplierID);

            supplier.CompanyName = Suppliers.CompanyName;
            supplier.ContactName = Suppliers.ContactName;
            supplier.ContactTitle = Suppliers.ContactTitle;
            supplier.Address = Suppliers.Address;
            supplier.City = Suppliers.City;
            supplier.Country = Suppliers.Country;
            supplier.Phone = Suppliers  .Phone;

            await _supplierRepository.Update(supplier);
        }
    }
}
