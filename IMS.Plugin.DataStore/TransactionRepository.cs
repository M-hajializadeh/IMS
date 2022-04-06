using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugin.DataStore
{
    public class TransactionRepository: ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionRepository()
        {
            transactions=new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string workerName)
        {
            if (string.IsNullOrWhiteSpace(workerName))
                return transactions;
            else
                return transactions.Where(t => string.Equals(t.WorkerName, workerName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetByDate(string workerName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(workerName))
                return transactions.Where(t => t.LeftInventoryTimeStamp.Date == date.Date);
            else
                return transactions.Where(t=>string.Equals(t.WorkerName,workerName, StringComparison.OrdinalIgnoreCase)
                &&  t.LeftInventoryTimeStamp.Date == date.Date);
        }

        public void Save(Transaction transaction)
        {
            var maxId = 0;
            if(transactions != null && transactions.Count>0)
                maxId=transactions.Max(t=>t.TransactionId);
            if (transaction == null) return;
            transaction.TransactionId = ++maxId;
            transactions.Add(transaction);

        }
    }
}
