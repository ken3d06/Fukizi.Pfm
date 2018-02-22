using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;

namespace Fukizi.Pfm.Services.Interfaces
{
    public interface ITransactionsService
    {
       void Create(Transaction transaction);
       void Save(Transaction transaction);
       IEnumerable<Transaction> GetTransactions();
   }
}
