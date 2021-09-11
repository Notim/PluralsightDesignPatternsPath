#nullable enable
using System;

namespace Singleton.NaiveSingletonImplementation
{

    public sealed class NaiveSingleton
    {

        public readonly int RandomNumber;

        private static NaiveSingleton? _instance;

        public static NaiveSingleton Instance {
            get {
                Console.Write("Instance Called.");
                return _instance ??= new NaiveSingleton();
            }
        }

        private NaiveSingleton()
        {
            RandomNumber = new Random().Next();
            Console.Write("Constructor invoked.");
        }

    }

}