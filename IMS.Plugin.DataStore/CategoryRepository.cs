using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugin.DataStore
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> Categories;
        public CategoryRepository()
        {
            Categories = new List<Category>()
            {
                new Category() { Id=1,Name = "دوربین", Description="توضیحاتی در مورد دوربین"},
                new Category() { Id=2,Name = "میکریفون", Description="توضیحاتی در مورد میکریفون"},
                new Category() { Id=3,Name = "مبدل", Description="توضیحاتی در مورد مبدل"},
                new Category() { Id=4,Name = "سه پایه", Description="توضیحاتی در مورد سه پایه"}
            };
        }
        public IEnumerable<Category> GetCategories()
        {
            return Categories;
        }
        public Category GetCategories(int id)
            => Categories?.FirstOrDefault(c => c.Id==id);
        public void AddCategory(Category category)
        {
            if (category == null)
                return;
            if (Categories.Contains(category))
                return;
            var maxId = 0;
            if (Categories.Count>0&& Categories!=null)
                maxId = Categories.Max(c => c.Id);
            category.Id = ++maxId;
           
            Categories.Add(category);
        }

        public void DeleteCategory(int id)
        {
            if (id == 0) return;
            var category = GetCategories(id);
            if (category != null)
                Categories.Remove(category);
        }

        public void EditCategory(Category category)
        {
            if (category == null) return;
            var categoryItem=GetCategories(category.Id);
            if (categoryItem != null)
            {
                categoryItem.Name = category.Name;
                categoryItem.Description = category.Description;
                
            }

        }
    }
}
