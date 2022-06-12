namespace WebStoreAutomobiles.Models.ViewModels
{
    public class ProductsListViewModels
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string Category { get; set; }
    }
}
