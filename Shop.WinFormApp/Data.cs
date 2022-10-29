namespace Shop.WinFormApp
{

    public class CategoryResult
    {
        public bool success { get; set; }
        public object message { get; set; }
        public Categories[] data { get; set; }
    }

    public class Categories
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
    }

}
