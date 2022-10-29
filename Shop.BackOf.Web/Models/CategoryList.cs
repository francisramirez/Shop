
namespace Shop.BackOf.Web.Models
{
    public class CategoryList
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
    }

    public class CategoryServiceResult : ServiceResult
    {
        public CategoryList[] data { get; set; }
    }

    public class ServiceResult 
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}
