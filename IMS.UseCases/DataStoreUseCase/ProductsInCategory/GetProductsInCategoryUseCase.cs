using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStoreUseCase.ProductsInCategory
{
    public class GetProductsInCategoryUseCase : IGetProductsInCategoryUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductsInCategoryUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> Execute(int categoryId)
        {
            return productRepository.GetProductByCategoryId(categoryId);
        }
    }
}
