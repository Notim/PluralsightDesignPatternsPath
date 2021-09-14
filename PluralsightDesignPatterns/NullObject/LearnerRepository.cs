using System.Collections.Generic;
using System.Linq;

namespace NullObject
{

    public class LearnerRepository
    {

        private readonly List<ILearner> _learners = new List<ILearner>(new ILearner[]{
            new Learner(1, "Joao Vitor Paulino", "Software engineer")
        });

        public ILearner GetLearner(int id)
        {
            var learner = this._learners.FirstOrDefault(x => x.Id == id);
            // searchOnDatabase 

            if (learner is null)
                return new NullLearner();

            return learner;
        }

    }

}