using Microsoft.EntityFrameworkCore;

namespace WebStoreAutomobiles.Models
{
    /// <summary>
    /// Файл контекста базы данных
    /// </summary>
    public class WebStoreDbContext:DbContext
    {
        public WebStoreDbContext(DbContextOptions<WebStoreDbContext> opts):base(opts)
        {

        }

        /// <summary>
        /// Таблица товаров
        /// </summary>
        public DbSet<Product> Products { get; set; }
    }
}
