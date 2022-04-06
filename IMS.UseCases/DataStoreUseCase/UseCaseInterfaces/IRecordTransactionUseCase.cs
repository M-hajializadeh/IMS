using IMS.CoreBusiness.Model;

namespace IMS.UseCases.DataStoreUseCase.Transactions
{
    public interface IRecordTransactionUseCase
    {
        void Execute(Transaction transaction);
    }
}