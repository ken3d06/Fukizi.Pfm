using System.Collections.Generic;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Repository;

namespace Fukizi.Pfm.Services
{
   internal class ExpenditureCategoryService : ICategoryService<ExpenditureCategory>
   {
      private ExpenditureCategoryRepository _expenditureCategoryRepository;

      public ExpenditureCategoryService(ExpenditureCategoryRepository expenditureCategoryRepository)
      {
         this._expenditureCategoryRepository = expenditureCategoryRepository;
      }

      public IEnumerable<Category> GetAllCategories()
      {
         throw new System.NotImplementedException();
      }

      public bool Exists(string name)
      {
         throw new System.NotImplementedException();
      }

      public ExpenditureCategory Create(string name, int id = 0)
      {
         throw new System.NotImplementedException();
      }

      public void Delete(string name)
      {
         throw new System.NotImplementedException();
      }

      public void Save(int id, string name)
      {
         throw new System.NotImplementedException();
      }
   }
}