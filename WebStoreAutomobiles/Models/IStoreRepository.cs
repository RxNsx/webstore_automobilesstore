namespace WebStoreAutomobiles.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
