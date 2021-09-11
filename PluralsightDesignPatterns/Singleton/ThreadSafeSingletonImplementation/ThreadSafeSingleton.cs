#nullable enable
using System;

namespace Singleton.ThreadSafeSingletonImplementation
{

    public sealed class ThreadSafeSingleton
    {

        public readonly int RandomNumber;

        private static ThreadSafeSingleton? _instance;

        private static readonly object padlock = new object();

        public static ThreadSafeSingleton Instance {
            get {
                Console.Write("Instance Called.");
                lock (padlock) {
                    return _instance ??= new ThreadSafeSingleton();
                }
            }
        }

        private ThreadSafeSingleton()
        {
            RandomNumber = new Random().Next();
            Console.Write("Constructor invoked.");
        }

    }

}