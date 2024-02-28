using System;
using System.Collections.Generic;
using System.Linq;

namespace D10
{
   
       

       
      public  class CustomComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x.Trim().OrderBy(c => c).SequenceEqual(y.Trim().OrderBy(c => c));
            }

            public int GetHashCode(string obj)
            {
                return obj.Trim().GetHashCode();
            }
        }
           



}
