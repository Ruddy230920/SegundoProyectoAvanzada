using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Services.DTO
{
  public class ProductsDTO
    {
       
        
            public int ProductID { get; set; }
            public string ProductName { get; set; } = null!;
            public string? QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public short UnitsInStock { get; set; }
            public short UnitsOnOrder { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public string? CategoryName { get; set; } = string.Empty;
        public string? CompanyName { get; set; } = string.Empty;
        public bool Discontinued { get; set; }
        





    }
    }

