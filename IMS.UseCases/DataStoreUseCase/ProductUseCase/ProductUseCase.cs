using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStoreUseCase.ProductUseCase
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository productRepository;

        public ProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> Execute()
        {
            return this.productRepository.GetProducts();
        }
    }
}
