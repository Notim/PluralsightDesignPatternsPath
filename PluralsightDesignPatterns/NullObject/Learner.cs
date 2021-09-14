namespace NullObject
{

    public class Learner : ILearner
    {

        public Learner(int id, string name, string job) => 
            (Id, Name, Job) = (id, name, job);
        
        public int Id { get; }

        public string Name { get; }

        public string Job { get; }

    }

}