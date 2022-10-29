
namespace Shop.Api.Models.ViewModel
{
    public class OrderDetailsViewModel
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
