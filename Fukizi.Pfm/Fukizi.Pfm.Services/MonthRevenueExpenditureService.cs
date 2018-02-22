using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Persistence;
using Fukizi.Pfm.Repository;

namespace Fukizi.Pfm.Services
{
   public class MonthRevenueExpenditureService
   {
      private readonly ExpenditureService _expenditureService;
      private readonly RevenueService _revenueService;
      public MonthRevenueExpenditureService(FukiziPfmDbContext context)
      {
         _expenditureService = new ExpenditureService(new ExpenditureRepository(context));
         _revenueService = new RevenueService(new RevenueRepository(context));
      }

      #region ExpendituresServices

      public List<Expenditure> GetMonthExpenditures(DateTime month)
      {
         return _expenditureService.LoadMonthExpenditures(month).ToList();
      }
      private decimal GetTotalExpenditureForMonth(DateTime month)
      {
         return _expenditureService.GetTotalExpenditureForMonth(month);
      }
      private decimal GetExpenditureTotalForCategoryAndMonth(string categoryName, DateTime month)
      {
         return _expenditureService.GetTotalForCategoryForGivenMonth(month, categoryName);
      }


      #endregion

      #region RevenuesServices
      public List<Revenue> GetMonthRevenues(DateTime month)
      {
         return _revenueService.LoadMonthRevenues(month).ToList();
      }
      private decimal GetTotalRevenueForMonth(DateTime month)
      {
         return _revenueService.GetTotalRevenueForMonth(month);
      }
      private decimal GetRevenueTotalForCategoryAndMonth(string categoryName, DateTime month)
      {
         return _revenueService.GetTotalForCategoryForGivenMonth(month, categoryName);
      }
      #endregion

   }
}
