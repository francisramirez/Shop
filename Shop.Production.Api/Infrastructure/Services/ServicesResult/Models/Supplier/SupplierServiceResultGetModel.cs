using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Models
{
    public class SupplierServiceResultGetModel
    {
        public int SupplierId { get; }
        public string CompanyName { get; }
        public string ContactName { get; }
        public string ContactTile { get; }
        public string Address { get; }
        public string City { get; }
        public string Region { get;}
        public string PostalCode { get; }
        public string Country { get; }
        public string Phone { get; }
        public string Fax { get; }

    }
}
