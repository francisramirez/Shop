using Shop.Shared.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Production.Api.Infrastructure.Data.Entities
{
    [Table("Suppliers", Schema = "Production")]
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
