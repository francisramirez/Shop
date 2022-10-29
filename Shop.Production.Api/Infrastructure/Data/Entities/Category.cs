using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Shared.Core;


namespace Shop.Production.Api.Infrastructure.Data.Entities
{
    [Table("Categories", Schema="Production")]
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
       
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
