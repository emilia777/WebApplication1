using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ProductDbContext _productContext;
        public ProductRepository(ProductDbContext context)
        {
            _productContext = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _productContext.Products.ToList();
        }
        public Product Get(long id)
        {
            return _productContext.Products.FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return _productContext.Products.Where(e => e.CategoryId == categoryId).ToList();
        }
        public IEnumerable<Product> GetByName(string productName)
        {
            return _productContext.Products.Where(e => e.Name.ToLower().Contains(productName.ToLower())).ToList();
        }
        public void Add(Product entity)
        {
            _productContext.Products.Add(entity);
            _productContext.SaveChanges();
        }
        public void Update(Product product, Product entity)
        {
            product.Name = entity.Name;
            product.Code = entity.Code;
           
            _productContext.SaveChanges();
        }
        public void Delete(Product product)
        {
            _productContext.Products.Remove(product);
            _productContext.SaveChanges();
        }
    }
}
