using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Repository;
using Fukizi.Pfm.Services.Interfaces;

namespace Fukizi.Pfm.Services
{
    public class RevenueService : ITransactionsService
    {
       private readonly RevenueRepository _revenueRepository;

       public RevenueService(RevenueRepository repository)
       {
          _revenueRepository = repository;
       }
       public void Create(Transaction transaction)
       {
          throw new NotImplementedException();
       }

       public void Save(Transaction transaction)
       {
          throw new NotImplementedException();
       }

       public IEnumerable<Transaction> GetTransactions()
       {
          throw new NotImplementedException();
       }
    }
}
