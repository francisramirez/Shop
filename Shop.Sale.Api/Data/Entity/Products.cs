using System;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Shared.Core; 

namespace Shop.Production.Api.Infrastructure.Data.Entities
{
    [Table("Products", Schema = "Production")]
    public class Products : BaseEntity
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
