using Shop.Shared.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Shop.Sale.Api.Data.Entity
{

    [Table(name: "Customers", Schema = "SALES")]
    public class Customers : BaseEntity
    {
        [Key]
        public int CustId { get; set; }
        public string CompanyName { get; set; }
        public string Contacttitle { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

    }
}
