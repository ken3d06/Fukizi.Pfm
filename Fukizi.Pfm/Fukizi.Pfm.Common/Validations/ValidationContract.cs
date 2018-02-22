using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Fukizi.Pfm.Common.Validations
{
    public class ValidationContract
    {
       public static void Requires<TException>(bool predicate, string message = "") where TException : Exception, new()
       {
          if (predicate) return;
          Debug.WriteLine(message);
          var ex = new TException();
          ex.GetType().GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ex, message);
          throw ex;
       }
   }
}
