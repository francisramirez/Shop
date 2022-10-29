using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Supplier
{
    public class SupplierServiceResultAddModel
    {
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(30)]
        public string ContactName { get; set; }
        [Required]
        [StringLength(30)]
        public string ContactTitle { get; set; }
        [Required]
        [StringLength(40)]
        public string Address { get; set; }
        [Required]
        [StringLength(15)]
        public string City { get; set; }
        [Required]
        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(15)]
        public string Country { get; set; }
        [Required]
        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        [Required]
        [Range(1, 100)]
        public int CreationUser { get; set; }
        [Required]
        public DateTime CreationDate { get; }

        public SupplierServiceResultAddModel()
        {
            CreationDate = System.DateTime.Now;
        }
    }
}
