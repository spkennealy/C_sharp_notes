using System;

namespace Singleton_Coding_Exercise
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var results1 = func();
            var results2 = func();
            return results1 == results2;
        }
    }
}
