namespace UdemyJWTApp.Back.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Defination { get; set; }
        public List<Product> Products { get; set; }
        
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
