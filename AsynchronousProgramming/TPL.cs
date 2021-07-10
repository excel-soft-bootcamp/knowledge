using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class Task_Parallel_Library
    {

        //Foreground Thread
        static void Main1()
        {

            System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
            _watch.Start();
              AsyncCall();

            _watch.Stop();
            Console.WriteLine(_watch.ElapsedMilliseconds);

        }


        static void SyncCall()
        {
            Search();
            SearchKey("abc");
           Console.WriteLine( SearchAndGetResult());
          Console.WriteLine(  SearchByKeyAndGetResult("xyz"));
        }
        static void AsyncCall()
        {
            Task _task1 = new Task(new Action(Task_Parallel_Library.Search));
            Task _task2 = new Task(new Action<object>(Task_Parallel_Library.SearchKey), "abc");

            Task<string> _task3 = new Task<string>(new Func<string>(Task_Parallel_Library.SearchAndGetResult));
            Task<string> _task4 =
                new Task<string>(
                    new Func<object, string>(Task_Parallel_Library.SearchByKeyAndGetResult),
                    "key");

            _task1.Start();//Back Ground  Thread
            _task2.Start();//Back Ground Thread
            _task3.Start();//Back Ground Thread
            _task4.Start();//Back Ground Thread

            Task.WaitAll(_task1, _task2, _task3, _task4);//Blocking Call
            string taskThreeResult = _task3.Result;
            string taskFourResult = _task4.Result;
            Console.WriteLine(taskThreeResult);
            Console.WriteLine(taskFourResult);
        }

        static void AsyncUsingTaskFactory()
        {
          Task _task1= Task.Factory.StartNew( new Action(Task_Parallel_Library.Search));

            Task _task2 =Task.Factory.StartNew(new Action<object>(Task_Parallel_Library.SearchKey), "abc");

            Task<string> _task3 = Task.Factory.StartNew<string>(new Func<string>(Task_Parallel_Library.SearchAndGetResult));
            Task<string> _task4 =
                Task.Factory.StartNew<string>(
                    new Func<object, string>(Task_Parallel_Library.SearchByKeyAndGetResult),
                    "key");

            Task.WaitAll(_task1, _task2, _task3, _task4);//Blocking Call
            string taskThreeResult = _task3.Result;
            string taskFourResult = _task4.Result;
            Console.WriteLine(taskThreeResult);
            Console.WriteLine(taskFourResult);
        }

        static void AsyncUsngRun()
        {
            Task _task1 = Task.Run(new Action(Task_Parallel_Library.Search));

         

            Task<string> _task3 = Task.Run<string>(new Func<string>(Task_Parallel_Library.SearchAndGetResult));
            
            Task.WaitAll(_task1, _task3);//Blocking Call
            string taskThreeResult = _task3.Result;
            
            Console.WriteLine(taskThreeResult);
            
        }

        static void Search() {
        
        for(int i = 0; i < 5; i++) { Console.WriteLine("Search in Progress");System.Threading.Thread.Sleep(1000); };
        }
        static void SearchKey(object key) {
            for (int i = 0; i < 10; i++) { Console.WriteLine($"Search  for  {key.ToString()} in Progress"); System.Threading.Thread.Sleep(1000); };
        }
        static string SearchAndGetResult() {

            for (int i = 0; i < 10; i++) { Console.WriteLine($"SearchAndGetResult in Progress"); System.Threading.Thread.Sleep(1000); };
            return " SearchAndGetResult Completed";

        }

        static string SearchByKeyAndGetResult(object key) {
            for (int i = 0; i < 10; i++) {
                Console.WriteLine($"SearchByKeyAndGetResult  {key.ToString()} in Progress"); System.Threading.Thread.Sleep(1000); };
            return " SearchByKeyAndGetResult Completed";
        }
    }
}
