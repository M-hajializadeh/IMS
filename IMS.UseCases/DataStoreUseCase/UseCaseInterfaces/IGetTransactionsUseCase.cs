using IMS.CoreBusiness.Model;

namespace IMS.UseCases.DataStoreUseCase.Transactions
{
    public interface IGetTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string workerName, DateTime startDate, DateTime endDate);
    }
}