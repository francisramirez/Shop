using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Category
{
    public class CategoryServiceResultModifyModel
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1, 100)]
        public int UserMod { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }

        public CategoryServiceResultModifyModel()
        {
            ModifyDate = System.DateTime.Now;
            this.UserMod = 1;
        }
    }
}
