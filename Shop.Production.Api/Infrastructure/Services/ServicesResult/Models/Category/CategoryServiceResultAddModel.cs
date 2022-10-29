using System;
using System.ComponentModel.DataAnnotations;
namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Category
{
    public class CategoryServiceResultAddModel
    {
         
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [Range(1, 100)]
        public int CreationUser { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        public CategoryServiceResultAddModel()
        {
            CreationDate = System.DateTime.Now;
            this.CreationUser = 1;
        }
    }
}
