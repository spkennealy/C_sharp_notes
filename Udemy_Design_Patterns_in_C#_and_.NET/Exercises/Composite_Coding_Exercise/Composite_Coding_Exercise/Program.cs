using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite_Coding_Exercise
{
    public interface IValueContainer
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }
}
