namespace WebStoreAutomobiles.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private WebStoreDbContext _context;

        public EFStoreRepository(WebStoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}
