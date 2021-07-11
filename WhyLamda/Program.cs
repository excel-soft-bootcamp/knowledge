using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyLamda
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Excel", "Mysore", "Mitra", "Vishwa", "Karma" };
            for(int i = 0; i < names.Length; i++)
            {
                if (names.Length > 3) { }
            }

            string[] cities = { "Bangalore", "Mysore", "Chennai", "Hyd", "Delhi" };
            string[] countries = { "India", "Germany", "Italy" };
            Iterate(names);
            Iterate(cities);
            Iterate(countries);
            Filter(names, new Func<string, bool>(CheckStringLengthGreaterThanThree));
            Filter(names, new Func<string, bool>(CheckStringLengthGreaterThanFive));
            
            Func<string, bool> _predicate = (string item) => { return item.Length > 2; };//Lamda Statement

            bool ItemLengthGreaterThanTwo(string item) { return item.Length >2 };
            Func<string, bool> _newPredicate = ItemLengthGreaterThanTwo;
                
            Filter(names, _predicate);
            Filter(names, ItemLengthGreaterThanTwo);

            Filter(names, (string item) => { return item.StartsWith("E"); });
            Filter(names, (item) => { return item.StartsWith("E"); });
            Filter(names, CheckStringLenthGreaterThanGivanLimit(1));
            Filter(names, CheckStringLenthGreaterThanGivanLimit(2));
            Filter(names, CheckStringLenthGreaterThanGivanLimit(3));
            Filter(names, CheckStringLenthGreaterThanGivanLimit(4));
            Filter(names, CheckStringLenthGreaterThanGivanLimit(5));
            GenericFilter<string>(names, (string item) => { return item.EndsWith("e"); });
            GenericFilter<int>(new int[] { 1, 2, 3, 4, 5 }, (int item) => { return item > 3; });
            GenericFilter<float>(new float[] { 3.3f,4.6f, 7.8f, 8.9f }, (float item) => { return true; });
            List<string> nameList = names.ToList();
           GenericFilterForEnumerable <string>(nameList, (string str) => { return str.Contains("abc"); });
            

        }
        //Predicate
        static bool CheckStringLengthGreaterThanThree(string item)
        {
            return item.Length > 3;
        }
        static bool CheckStringLengthGreaterThanFive(string item)
        {
            return item.Length > 5;
        }

        static Func<string,bool> CheckStringLenthGreaterThanGivanLimit(int limit)
        {
            //Func<string, bool> _predicate = (string item) => {
            //    return item.Length > limit; };

            //return _predicate;

            //LocalFunction 
            bool Predicate(string item)
            {
                return item.Length > limit;
            }
            return Predicate;

        }
        static List<string> Iterate(string[] source)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].Length > 3)
                {
                    result.Add(source[i]);
                }
            }
            return result;
        }
        static List<string> Filter(string[] source,Func<string,bool> predicate)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < source.Length; i++)
            {
                if (predicate.Invoke(source[i]))
                {
                    result.Add(source[i]);
                }
            }
            return result;
        }

        static List<T> GenericFilter<T>(T[] source,Func<T,bool> predicate)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < source.Length; i++)
            {
                if (predicate.Invoke(source[i]))
                {
                    result.Add(source[i]);
                }
            }
            return result;

        }
        static IEnumerable<T> GenericFilterForEnumerable<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();

           IEnumerator<T> _iterator= source.GetEnumerator();
            foreach (T item in source)
            {
                if (predicate.Invoke(item))
                {
                    result.Add(item);
                }

            }
            return result;

            #region Iterator Interaction Code
            //try
            //{
            //    while (_iterator.MoveNext())
            //    {
            //        T item = _iterator.Current;
            //        if (predicate.Invoke(item))
            //        {
            //            result.Add(item);
            //        }
            //    }
            //}
            //finally
            //{
            //    _iterator.Dispose();
            //}
            #endregion



        }


    }
}
