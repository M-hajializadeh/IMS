using IMS.CoreBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get(string workerName);
        IEnumerable<Transaction> GetByDate(string workerName, DateTime date);
        void Save(Transaction transaction);
        IEnumerable<Transaction> Search(string workerName, DateTime startDate, DateTime endDate);
    }
}
