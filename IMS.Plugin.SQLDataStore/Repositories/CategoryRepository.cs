using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugin.SQLDataStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddCategory(Category category)
        {
            dbContext.Add(category);
            dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var Cateogry= GetCategories(id);
            if (Cateogry == null) return;
            dbContext.Categories.Remove(Cateogry);
            dbContext.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            dbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }

        public Category GetCategories(int id)
        {
            return dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
