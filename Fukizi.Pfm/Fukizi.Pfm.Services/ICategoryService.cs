using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;

namespace Fukizi.Pfm.Services
{
    public interface ICategoryService<out TCategoryType>
    {
       IEnumerable<Category> GetAllCategories();
       bool Exists(string name);
       TCategoryType Create(string name, int id = 0);
       void Delete(string name);
       void Save(int id, string name);
   }
}
