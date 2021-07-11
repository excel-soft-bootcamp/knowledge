using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelfost.Linq
{
    public static class TypeExtesnionMethods
    {

        //Extension Method
        public static bool Validate(this int source, int value)
        {

            return source == value;
        }
        public static bool Validate(this string source, string value)
        {
            return false;
        }
    }
}
