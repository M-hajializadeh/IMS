using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStoreUseCase.Transactions
{
    public class GetTodayTransactionUseCase : IGetTodayTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTodayTransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string workerName)
        {
            return transactionRepository.GetByDate(workerName, DateTime.Now);
        }
    }
}
