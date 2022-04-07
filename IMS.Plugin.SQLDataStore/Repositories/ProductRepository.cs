using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugin.SQLDataStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddProduct(Product product)
        {
            if (product == null) return;
            dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            dbContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            if(productId == 0) return;
            var product=GetProduct(productId);
            dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            if (id == 0) return null;
            return dbContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public Product GetProduct(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) return null;
            return dbContext.Products.SingleOrDefault(p => p.Name == name);
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            if(categoryId == 0) return null;
            return dbContext.Products.Where(p => p.CategoryId == categoryId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products;
        }

        public void UpdateProduct(Product product)
        {
            if(product == null) return;
            dbContext.Entry(product).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
