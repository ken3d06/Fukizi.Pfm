using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;

namespace Fukizi.Pfm.Services
{
    public class RevenueCategoryService : ICategoryService<RevenueCategory>
    {
       public IEnumerable<Category> GetAllCategories()
       {
          throw new NotImplementedException();
       }

       public bool Exists(string name)
       {
          throw new NotImplementedException();
       }

       public RevenueCategory Create(string name, int id = 0)
       {
          throw new NotImplementedException();
       }

       public void Delete(string name)
       {
          throw new NotImplementedException();
       }

       public void Save(int id, string name)
       {
          throw new NotImplementedException();
       }
    }
}
