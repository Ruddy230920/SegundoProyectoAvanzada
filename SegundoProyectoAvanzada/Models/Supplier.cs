using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string? CompanyName { get; set; }
        public string ContactName { get; set; } = null!;
        public string ContactTitle { get; set; } = null!;
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
