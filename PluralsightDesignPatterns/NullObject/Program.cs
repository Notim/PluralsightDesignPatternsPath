using System;

namespace NullObject
{

    internal class Program
    {

        private static void Main(string[] args)
        {
            var learnerRepository = new LearnerRepository();

            var learner = learnerRepository.GetLearner(1);
            var nullLearner = learnerRepository.GetLearner(-1);
            
            Console.WriteLine(Print(learner));
            
            Console.WriteLine("----------------------------------------");
            
            Console.WriteLine(Print(nullLearner));
        }
        
        public static string Print(ILearner learner) 
            => $"{learner.Id}\n{learner.Name}\n{learner.Job}";

    }

}