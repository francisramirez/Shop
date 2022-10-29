using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Sale.Api.Data.Entity
{
    [Table(name:"OrderDetails",Schema ="Sales")]
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short QTY { get; set; }
        public decimal Discount { get; set; }
    }
}
