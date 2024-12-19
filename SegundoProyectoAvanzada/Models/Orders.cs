using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Models
{
    public class Orders
    {
        [Key]
        public int? OrderID { get; set; }

        public string? CustomerID { get; set; } 
        [ForeignKey("CustomerID")]
        public virtual Customers Customers { get; set; }

        public int? EmployeeID { get; set; } 
        [ForeignKey("EmployeeID")]
        public virtual Employees Employees { get; set; }

        public int? ShipVia { get; set; } 
        [ForeignKey("ShipVia")]
        public virtual Shippers Shippers { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
    }
}
