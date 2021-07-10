public class A{

}
public class Test{
	public void M1(){}
	public void M2(){}
	public string M3(){}
	public void M4(string data){}
        public int M5(string data,int newData){}
        public A M6(string data){}
	public string M7(A obj){}
	public void M8(int x, string y,decimal z){}
	public A M9(A obj,int y){}


}
public delegate string DelegateClassName(A obj);
public delegate int DelegateClassName(string data,int newData);
public delegate void DelegateClassName();
public delegate A DelegateClassName(string data);

//Two built in delegate types



//Action - void(0 to 16 parameters of Given Type)
//Func    - ReturnType(16 Parameters Og Given Type)

Main(){
                Test obj=new Test();
				Action m1ptr=new Action(obj.M1);
				Action m2Ptr=new  Action(obj.M2);
				Action<string> m4Ptr=new Action<string>(obj.M4);
				Action<int,string,decimal> testPtr=new Action<int,string,decimal>(obj.M8);
				
				Func<string> m3Ptr=new Func<string>(obj.M3);
				Func<string,int,int> m5Ptr=new Func<string,int,int>(obj.M5);
				Func<string,A> m6Ptr=new  Func<string,A>(obj.M6);
				Func<A,string> m7Ptr=new  Func<A,string>(obj.M7);
				Func<A,int,A> m9Ptr=new Func<A,int,A>();
				
				
}

