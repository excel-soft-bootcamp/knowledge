using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excelfost.Linq;
using System.Threading.Tasks;

namespace WhyLinq
{
  
    class ExtensionMethdos
    {
        
        static void Method()
        {
            //Int32 x=new Int32();
            int x= 10;
            
            x.Validate(10);// TypeExtesnionMethods.Validate(x, 10);
            bool isValid= TypeExtesnionMethods.Validate(x, 10);
                //bool isValid=  x.Validate(10);
                string item = "abc";
                item.Validate("abc");
           
        }
    }
}
