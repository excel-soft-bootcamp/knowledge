using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;//Task Parallel Library

namespace AsynchronousProgramming
{
    class Program
    {
        static void UI(string[] args)
        {
            Search_Button_Click();
            Edit_Comments();
        }
        static void Edit_Comments() {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Editing Comments");
                System.Threading.Thread.Sleep(1000);
            }
        
        }
        static void Search_Button_Click()
        {
            // InteractDB(); Synchronus Call
            Action _interactDBFunPtr = new Action(Program.InteractDB);
            Task _interactDBTask = new Task(_interactDBFunPtr);
            _interactDBTask.Start();
            //.....
            //...

            //.....
            //_interactDBTask.Wait();
            //_interactDBTask.Status
                

        }

        //Task
        static void InteractDB()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Interacting With DB");
                System.Threading.Thread.Sleep(1000);
                
            }
        }
    }
}
