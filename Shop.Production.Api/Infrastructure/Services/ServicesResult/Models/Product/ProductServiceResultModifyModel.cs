using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Product
{
    public class ProductServiceResultModifyModel
    {
        [Required]
        [Range(1, 300)]
        public int ProductId { get; set; }
        [StringLength(20)]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name  is mandatory")]
        public string ProductName { get; set; }
        [Required]
        [Range(1, 300)]
        //Validar que el id del suplidor esta en la base de datos sin estar eliminado
        public int SupplierId { get; set; }
        [Required]
        [Range(1, 300)]
        //Validar que el id de la categoria esta en la base de datos sin estar eliminado
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Unit Price is mandatory")]
        [Range(1, 500000)]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Discontinued is mandatory")]
        public bool Discontinued { get; set; }
        [Required]
        [Range(1, 300)]
        public int UserMod { get; set; }
        public DateTime ModifyDate { get; }

        public ProductServiceResultModifyModel()
        {
            this.ModifyDate = System.DateTime.Now;
        }


    }
}
