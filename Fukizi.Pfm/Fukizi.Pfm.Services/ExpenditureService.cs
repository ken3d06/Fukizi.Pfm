using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fukizi.Pfm.Common.Validations;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Repository;
using Fukizi.Pfm.Services.Interfaces;

namespace Fukizi.Pfm.Services
{
    public class ExpenditureService : ITransactionsService
    {
       private readonly ExpenditureRepository _expenditureRepository;

       public ExpenditureService(ExpenditureRepository repository)
       {
          _expenditureRepository = repository;
       }
       public void Create(Transaction transaction)
       {
          var expenditure = TransactionExtensions.TryParseToExpenditure(transaction);
          CreateNewExpenditure(expenditure);
       }

       private void CreateNewExpenditure(Expenditure expenditure)
       {
          ValidationContract.Required<ArgumentNullException>(expenditure != null, "Expenditure can never be null");
          ValidationContract.Required<ArgumentException>(expenditure != null && expenditure.CategoryId > 0, "At least one Category must be selected");
          ValidationContract.Required<ArgumentException>(expenditure != null && expenditure.PayMethodId > 0, "At least one payment method must be selected");
          _expenditureRepository.CreateExpenditure(expenditure);
       }

       public void Save(Transaction transaction)
       {
          var expenditure = TransactionExtensions.TryParseToExpenditure(transaction);
          SaveExpenditure(expenditure);
       }

       private void SaveExpenditure(Expenditure expenditure)
       {
          ValidationContract.Required<ArgumentNullException>(expenditure != null, "Expenditure can never be null");
          ValidationContract.Required<ArgumentException>(expenditure != null && expenditure.CategoryId > 0, "At least one Category must be selected");
          ValidationContract.Required<ArgumentException>(expenditure != null && expenditure.PayMethodId > 0, "At least one payment method must be selected");
          _expenditureRepository.SaveExpenditure(expenditure);
       }

       public void DeleteExpenditure(int id)
       {
          _expenditureRepository.DeleteExpenditure(id);
       }
       public IEnumerable<Transaction> GetTransactions()
       {
          return LoadExpenditures();
       }

       public Expenditure LoadExpenditure(int id)
       {
          return _expenditureRepository.GetExpenditure(id);
       }

       public IEnumerable<Expenditure> LoadExpenditures()
       {
          return _expenditureRepository.GetExpenditures();
       }

       public IEnumerable<Expenditure> LoadMonthExpenditures(DateTime datetime)
       {
          return _expenditureRepository.GetExpendituresForMonthAndYear(datetime.Month, datetime.Year);
       }

       #region ExpenditureCalculations

       public decimal GetTotalExpenditureForMonth(DateTime datetime)
       {
          return LoadMonthExpenditures(datetime).Sum(e => e.Amount);
       }

       public decimal GetTotalForCategoryForGivenMonth(DateTime datetime, string givenCategory)
       {
          ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(givenCategory), "Category must have a value");
          return LoadMonthExpenditures(datetime)
             .Where(exp => exp.Category.Name.Equals(givenCategory, StringComparison.OrdinalIgnoreCase))
             .Sum(exp => exp.Amount);
       }
       public Dictionary<string, decimal> GetExpenditureTotalsForAllCategoriesForMonth(DateTime datetime)
       {
          return LoadMonthExpenditures(datetime)
             .GroupBy(e => e.Category.Name)
             .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));
       }
       public decimal GetExpenditureTotalsForMonthByPayMethod(DateTime datetime, string payMethod)
       {
          ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(payMethod), "Pay method must not be null");
          return LoadMonthExpenditures(datetime)
             .Where(e => e.PayMethod.Name.Equals(payMethod, StringComparison.OrdinalIgnoreCase))
             .Sum(e => e.Amount);
       }
       public Dictionary<string, decimal> GetExpenditureTotalsForMonthForAllPayMethods(DateTime datetime)
       {
          return LoadMonthExpenditures(datetime)
             .GroupBy(r => r.PayMethod.Name)
             .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));
       }
       #endregion
   }
}
