using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Supplier
{
    public class SupplierServiceResultModifyModel
    {
        [Required]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(30)]
        public string contactName { get; set; }
        [Required]
        [StringLength(30)]
        public string ContactTitle { get; set; }
        [Required]
        [StringLength(15)]
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
        public int UserMod { get; set; }
        [Required]
        public DateTime ModifyDate { get; }
        public SupplierServiceResultModifyModel()
        {
            ModifyDate = System.DateTime.Now;
        }
    }
}
