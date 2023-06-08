using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IProductRepository : IDataRepository<Product>
    {
        IEnumerable<Product> GetByCategoryId(int categoryId);
        IEnumerable<Product> GetByName(string productName);
    }
}
