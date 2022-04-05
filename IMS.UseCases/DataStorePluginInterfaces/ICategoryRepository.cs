using IMS.CoreBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        Category GetCategories(int id);
        void AddCategory(Category category);
        void DeleteCategory(int id);
        void EditCategory(Category category);
    }
}
