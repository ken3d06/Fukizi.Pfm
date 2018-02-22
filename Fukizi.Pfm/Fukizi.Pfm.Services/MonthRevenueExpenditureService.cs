using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fukizi.Pfm.Common.Validations;
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

      #region BothRevenueAndExpenditure

      public decimal GetTotalForCategoryAndMonth(string categoryType, string categoryName, DateTime month)
      {
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(categoryType), "Category type must be specified");
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(categoryName), "Category name must be specified");

            switch (categoryType?.ToLower())
            {
               case "expenditure":
               {
                  return GetExpenditureTotalForCategoryAndMonth(categoryName, month);
               }
               case "revenue":
               {
                  return GetRevenueTotalForCategoryAndMonth(categoryName, month);
               }
               default:
               {
                  return 0;
               }
            }
      }

      public Dictionary<string, decimal> GetTotalFlowPerCategoriesForMonth(DateTime month)
      {
         var categoryTotals = new Dictionary<string, decimal>
         {
            {"Total Expenditures", GetTotalExpenditureForMonth(month)},
            {"Total Revenue", GetTotalRevenueForMonth(month)}
         };
         //ToDo: add this range to dictionary
         //categoryTotals.AddRange(_expenditureService.GetExpenditureTotalsForAllCategoriesForMonth(month));

         foreach (var totalRevenueByCategory in _revenueService.GetRevenueTotalsForAllCategoriesForMonth(month))
         {
            if (categoryTotals.ContainsKey(totalRevenueByCategory.Key))
            {
               var placeholder = categoryTotals[totalRevenueByCategory.Key];
               categoryTotals.Remove(totalRevenueByCategory.Key);
               categoryTotals.Add($"{totalRevenueByCategory.Key} - Expenditure", placeholder);
               categoryTotals.Add($"{totalRevenueByCategory.Key} - revenue", totalRevenueByCategory.Value);
            }
            else
            {
               categoryTotals.Add(totalRevenueByCategory.Key, totalRevenueByCategory.Value);
            }
         }

         return categoryTotals;
      }

      #endregion

   }
}
