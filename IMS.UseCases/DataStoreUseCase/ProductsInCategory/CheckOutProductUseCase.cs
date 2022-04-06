using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using IMS.UseCases.DataStoreUseCase.Transactions;
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
        private readonly IRecordTransactionUseCase transactionUseCase;

        public CheckOutProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase transactionUseCase)
        {
            this.productRepository = productRepository;
            this.transactionUseCase = transactionUseCase;
        }
        public void Execute(string workerName,int productId, int qtyToCkeckOut)
        {
            var product = this.productRepository.GetProduct(productId);
            if (product == null) return;
            transactionUseCase.Execute(new Transaction
            {
                CheckOutQty = qtyToCkeckOut,
                ProdcutId = productId,
                ProductName= product.Name,
                BeforeQty = product.Quntity,
                WorkerName = workerName,
                LeftInventoryTimeStamp = DateTime.Now
            }) ;
            product.Quntity -= qtyToCkeckOut;
            this.productRepository.UpdateProduct(product);
        }
    }
}
