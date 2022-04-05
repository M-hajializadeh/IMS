using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStoreUseCase.ProductUseCase
{
    public class GetProductUseCase : IGetProductUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product Execute(int productId)
        {
            return this.productRepository.GetProduct(productId);
        }
    }
}
