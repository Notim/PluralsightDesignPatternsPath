#nullable enable
using System;

namespace Singleton.LazySingletonImplementation
{

    public sealed class LazySingleton
    {

        public readonly int RandomNumber;

        private static readonly Lazy<LazySingleton> _lazy = new(() => new LazySingleton());

        public static LazySingleton Instance {
            get {
                Console.Write("Instance Called.");

                return _lazy.Value;
            }
        }

        private LazySingleton()
        {
            RandomNumber = new Random().Next();
            Console.Write("Constructor invoked.");
        }

    }

}