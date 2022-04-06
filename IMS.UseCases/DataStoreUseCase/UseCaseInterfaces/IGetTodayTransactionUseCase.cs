using IMS.CoreBusiness.Model;

namespace IMS.UseCases.DataStoreUseCase.Transactions
{
    public interface IGetTodayTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string workerName);
    }
}