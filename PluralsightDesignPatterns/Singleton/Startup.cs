using System;

using Singleton.LazySingletonImplementation;
using Singleton.NaiveSingletonImplementation;
using Singleton.NestedSingletonImplementation;
using Singleton.ThreadSafeSingletonImplementation;

namespace Singleton
{

    internal class Startup
    {

        public static void Start(string[] args)
        {
            Console.WriteLine(NaiveSingleton.Instance.RandomNumber);
            Console.WriteLine(NaiveSingleton.Instance.RandomNumber);
            Console.WriteLine(NaiveSingleton.Instance.RandomNumber);

            Console.WriteLine(ThreadSafeSingleton.Instance.RandomNumber);
            Console.WriteLine(ThreadSafeSingleton.Instance.RandomNumber);
            Console.WriteLine(ThreadSafeSingleton.Instance.RandomNumber);
            
            Console.WriteLine(NestedSingleton.Instance.RandomNumber);
            Console.WriteLine(NestedSingleton.Instance.RandomNumber);
            Console.WriteLine(NestedSingleton.Instance.RandomNumber);

            Console.WriteLine(LazySingleton.Instance.RandomNumber);
            Console.WriteLine(LazySingleton.Instance.RandomNumber);
            Console.WriteLine(LazySingleton.Instance.RandomNumber);
        }

    }

}