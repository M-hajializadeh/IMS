using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugin.SQLDataStore.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext dbContext;

        public TransactionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Transaction> Get(string workerName)
        {
            if (string.IsNullOrWhiteSpace(workerName))
                return dbContext.Transactions;
            else
                return dbContext.Transactions.Where(t => string.Equals(t.WorkerName.ToLower(), workerName.ToLower()));
        }

        public IEnumerable<Transaction> GetByDate(string workerName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(workerName))
                return dbContext.Transactions.Where(t => t.LeftInventoryTimeStamp.Date == date.Date);
            else
                return dbContext.Transactions.Where(t => string.Equals(t.WorkerName.ToLower(), workerName.ToLower()) &&
                t.LeftInventoryTimeStamp.Date == date.Date);
        }

        public void Save(Transaction transaction)
        {
            if (transaction == null) return;
            dbContext.Entry(transaction).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            dbContext.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string workerName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(workerName))
                return dbContext.Transactions.Where(t => t.LeftInventoryTimeStamp >= startDate.Date && 
                                                         t.LeftInventoryTimeStamp <= endDate.Date.AddDays(1).Date);
            else
                return dbContext.Transactions.Where(t => string.Equals(t.WorkerName.ToLower(), workerName.ToLower()) &&
                                                 t.LeftInventoryTimeStamp >= startDate.Date &&
                                                 t.LeftInventoryTimeStamp <= endDate.Date.AddDays(1).Date
                                              );
        }
    }
}
