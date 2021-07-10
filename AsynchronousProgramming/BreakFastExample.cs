using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{

    class BreaksfastSample
    {
        static void Main(string[] args)
        {
           // SyncCode();
           // AsyncCode();
            PrepareBreakFast();
            Console.ReadKey();
        }
        private static void SyncCode()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static  void AsyncCode()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Task<Egg> _fryEggTask = Task.Factory.StartNew<Egg>(new Func<object, Egg>(BreaksfastSample.FryEggsWrapper), 2);
           _fryEggTask.Wait();
            Egg _egg= _fryEggTask.Result;
            Console.WriteLine("eggs are ready");
            Task<Bacon> _fryBaconTask = Task.Factory.StartNew<Bacon>(new Func<object, Bacon>(BreaksfastSample.FryBaconWrapper), 2);
            _fryBaconTask.Wait();
           Bacon _bacon= _fryBaconTask.Result;
            Console.WriteLine("bacon is ready");
            Task<Toast> _toastBreadTask = Task.Factory.StartNew<Toast>(new Func<object, Toast>(BreaksfastSample.ToastBreadWrapper), 2);
           _toastBreadTask.Wait();
            Toast _toast = _toastBreadTask.Result;
            ApplyButter(_toast);
            ApplyJam(_toast);
            Console.WriteLine("toast is ready");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        //async - method returns void/Task/Task<dataType>
        private static async void PrepareBreakFast()
        {
            Coffee _coffee = PourCoffee();
            Console.WriteLine("Coffee is ready");
            Egg _egg = await Task.Factory.StartNew<Egg>(new Func<object, Egg>(BreaksfastSample.FryEggsWrapper), 2);
            Console.WriteLine("eggs are ready");
            Bacon _bacon = await Task.Factory.StartNew<Bacon>(new Func<object, Bacon>(BreaksfastSample.FryBaconWrapper), 2);
            Console.WriteLine("bacon is ready");
            Toast _toast = await Task.Factory.StartNew<Toast>(new Func<object, Toast>(BreaksfastSample.ToastBreadWrapper), 2);
            ApplyButter(_toast);
            ApplyJam(_toast);
            Console.WriteLine("Toast is ready");
            Juice juice = PourOJ();
            Console.WriteLine("Juice is ready");
            Console.ReadKey();

        }
        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBreadWrapper(object slices)
        {
            return ToastBread((int)slices);
        }
        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBaconWrapper(object slices)
        {
            return FryBacon((int)slices);
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

       private static Task<Egg> FryEggsAsync(int howMany)
        {
            return Task.Run(() => {
                return FryEggs(howMany);
            
            }); 

        }
        private static Egg FryEggsWrapper(object howmany)
        {
            return FryEggs((int)howmany);
        }
        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}

