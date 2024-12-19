using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Avanzada.DTO
{
  public class SupplierDTO
    {
        public int SupplierID { get; set; }
        public string? CompanyName { get; set; }
        public string ContactName { get; set; } = null!;
        public string ContactTitle { get; set; } = null!;
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }

    }
}
