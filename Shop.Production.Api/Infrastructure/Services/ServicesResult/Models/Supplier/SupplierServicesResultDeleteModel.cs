using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Supplier
{
    public class SupplierServicesResultDeleteModel
    {
        [Required]
        public int UserDeleted { get; set; }
        [Required]
        public DateTime DeletedDate { get; }
        [Required]
        public bool Deleted { get; set; }

        public SupplierServicesResultDeleteModel()
        {
            DeletedDate = System.DateTime.Now;
            Deleted = true;
        }
  
    }
}
