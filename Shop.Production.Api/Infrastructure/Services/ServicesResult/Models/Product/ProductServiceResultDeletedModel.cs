using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Product
{
    public class ProductServiceResultDeletedModel
    {
        public int ProductId { get; set; }
        public bool Deleted { get; set; }
        public int UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }

        public ProductServiceResultDeletedModel()
        {
            this.DeletedDate = System.DateTime.Now;
        }

    }
}
