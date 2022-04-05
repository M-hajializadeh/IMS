using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStoreUseCase.ProductsInCategory
{
    public class CheckOutProductUseCase : ICheckOutProductUseCase
    {
        private readonly IProductRepository productRepository;

        public CheckOutProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Execute(int productId, int qtyToCkeckOut)
        {
            var product = this.productRepository.GetProduct(productId);
            if (product == null) return;
            product.Quntity -= qtyToCkeckOut;
            this.productRepository.UpdateProduct(product);
        }
    }
}
