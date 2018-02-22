using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Common.Validations;
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
         var revenue = TransactionExtensions.TryParseToRevenue(transaction);
         CreateNewRevenue(revenue);
      }

      private void CreateNewRevenue(Revenue revenue)
      {
         ValidationContract.Required<ArgumentNullException>(revenue != null, "Revenue can never be null");
         ValidationContract.Required<ArgumentException>(revenue != null && revenue.CategoryId > 0, "At least one Category must be selected");
         ValidationContract.Required<ArgumentException>(revenue != null && revenue.PayMethodId > 0, "At least one payment method must be selected");
         _revenueRepository.CreateRevenue(revenue);
      }

      public void Save(Transaction transaction)
      {
         var revenue = TransactionExtensions.TryParseToRevenue(transaction) ;
         SaveRevenue(revenue);
      }

      private void SaveRevenue(Revenue revenue)
      {
         ValidationContract.Required<ArgumentNullException>(revenue != null, "Revenue can never be null");
         ValidationContract.Required<ArgumentException>(revenue != null && revenue.CategoryId > 0, "At least one Category must be selected");
         ValidationContract.Required<ArgumentException>(revenue != null && revenue.PayMethodId > 0, "At least one payment method must be selected");
         _revenueRepository.SaveRevenue(revenue);
      }

      public IEnumerable<Transaction> GetTransactions()
      {
         return  LoadRevenues() ;
      }

      public Revenue LoadRevenue(int id)
      {
         return _revenueRepository.GetRevenue(id);
      }

      public IEnumerable<Revenue> LoadRevenues()
      {
         return _revenueRepository.GetRevenues();
      }

      public IEnumerable<Revenue> LoadMonthRevenues(DateTime datetime)
      {
         return _revenueRepository.GetRevenuesForMonthAndYear(datetime.Month, datetime.Year);
      }
   }
}
