using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStoreUseCase.Category
{
    public class ViewCategoryUseCase : IViewCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IEnumerable<IMS.CoreBusiness.Model.Category> Execute()
        {
            return categoryRepository.GetCategories();
        }
    }
}
