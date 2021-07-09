using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenProgram
{
    //delegate - is a Class 
    delegate void VoidMethodDelegate();
    /*
     * class VoidMethodDelegate{
     * 
     *   public void Invoke(){}
     * 
     * }
     * 
     */
    delegate int IntReturnTypeDelegate();
    /*
    * class IntReturnTypeDelegate{
    * 
    *   public int Invoke(){}
    * 
    * }
    * 
    */
    delegate int IntReturnStringArgumentDelegate(string data);
    /* 
     * class IntReturnStringArgumentDelegate
     * {
     *    public int Invoke(string data){
     *    }
     * }
     */ 

    

  
    class Program
    {
        static void Foo()
        {
           

        }
        static int NewFoo1() { throw new NotFiniteNumberException(); }
        int NewFoo2() { throw new NotFiniteNumberException(); }
       static int EnoughFoo(string data) { throw new NotFiniteNumberException(); }
        static void Main_old(string[] args)
        {
            int data = 20;
            //Delegate Instantiation
            VoidMethodDelegate fooMethodObj = new VoidMethodDelegate(Program.Foo);
            Program _programObj = new Program();
            IntReturnTypeDelegate newFoo1MethodObj = new IntReturnTypeDelegate(_programObj.NewFoo2);
            IntReturnTypeDelegate newFoo2MethodObj = new IntReturnTypeDelegate(Program.NewFoo1);
            //System.Delegate.Combine(newFoo1MethodObj, newFoo2MethodObj);
            newFoo1MethodObj += newFoo2MethodObj;
            
            IntReturnStringArgumentDelegate enoughFooMethodObj = new IntReturnStringArgumentDelegate(Program.EnoughFoo);
            Fun(data, fooMethodObj, newFoo1MethodObj, enoughFooMethodObj);
      

        }
       static void Fun(int param,
           VoidMethodDelegate voidfunobj,
           IntReturnTypeDelegate intFunObj,
           IntReturnStringArgumentDelegate intReturnStringFunObj)
        {
            voidfunobj.Invoke();
            int result = intFunObj.Invoke();
           result= intReturnStringFunObj.Invoke("hi");
        }

        static void Main()
        {
            Parent _observer_parent = new Parent();
            JobStatusHanlder _addressOfNotify = new JobStatusHanlder(_observer_parent.Notify);

            Friend _observer_friend = new Friend();
            JobStatusHanlder _addressOfUpdate = new JobStatusHanlder(_observer_friend.Update);


            
            Child _elder = new Child();
              //Subscribe
           /* _elder.OnJobStatusChanged += _addressOfNotify; //Add_observer
            _elder.OnJobStatusChanged+= _addressOfUpdate; //Add_observer
            */
            _elder.Add_Observer(_addressOfNotify);
            _elder.Add_Observer(_addressOfUpdate);

            Child _younger = new Child();
            _elder.GotNewJob();
            
        }
    }
}
