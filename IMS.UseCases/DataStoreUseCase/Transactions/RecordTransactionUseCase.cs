using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using IMS.UseCases.DataStoreUseCase.ProductUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStoreUseCase.Transactions
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductUseCase getProductUseCase;

        public RecordTransactionUseCase(ITransactionRepository transactionRepository, IGetProductUseCase getProductUseCase)
        {
            this.transactionRepository = transactionRepository;
            this.getProductUseCase = getProductUseCase;
        }
        public void Execute(Transaction transaction)
        {
            if (transaction == null) return;
            transaction.ProductName = getProductUseCase.Execute(transaction.ProdcutId).Name;
            this.transactionRepository.Save(transaction);
        }
    }
}
