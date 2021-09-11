using System;

namespace Singleton.NestedSingletonImplementation
{

    public sealed class NestedSingleton
    {

        public readonly int RandomNumber;

        public static NestedSingleton Instance {
            get {
                Console.Write("Instance Called.");
                return Nested._instance;
            }
        }

        private class Nested
        {

            static Nested()
            { }

            internal static readonly NestedSingleton _instance = new NestedSingleton();

        }

        private NestedSingleton()
        {
            Console.Write("Constructor Invoked.");
            RandomNumber = new Random().Next();
        }

    }

}