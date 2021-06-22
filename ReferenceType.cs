using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class ReferenceType
    {
        //Encapsulate
        #region Fields
        private int x;
       private  static int y;
        #endregion
        #region Mutators/functions
        //public void setx(ReferenceType this,int value)
        public void Setx(int value) {
            this.x = value;
        }

        public int GetX() { return this.x; }
        #endregion
    }

    struct ValueType
    {
        int x;
        public void Setx(int value) { this.x = value; }
    }

    class EntryPoint
    {
        static void Main_old()
        {
            int x = 100;//value type, method scope(stack)

            ReferenceType obj1 = new ReferenceType();
            obj1.Setx(100);//ReferenceType.setx(obj1,100);
            ReferenceType obj2 = new ReferenceType();
            obj2.Setx(200);
            ReferenceType obj3 = new ReferenceType();
            obj3.Setx(400);

            Console.WriteLine(obj1.GetX());
            Console.WriteLine(obj2.GetX());
            Console.WriteLine(obj3.GetX());

        }

        static void Main()
        {
            ValueType obj1 = new ValueType();
            obj1.Setx(100);
            Test(obj1);
            ReferenceType obj2 = new ReferenceType();
            NewTest(obj2);
        }
        static void Test(ValueType arg)
        {
            arg.Setx(300);
        }
        static void NewTest(ReferenceType arg)
        {
            arg.Setx(500);
        }
    }
}
