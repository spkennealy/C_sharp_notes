using System.Collections.Generic;

namespace Design_A_Workflow_Engine
{
    public class Workflow
    {
        public readonly IList<IActivity> Activities;

        public Workflow()
        {
            Activities = new List<IActivity>();
        }

        public void Add(IActivity activity)
        {
            Activities.Add(activity);
        }

        public void Remove(IActivity activity)
        {
            Activities.Remove(activity);
        }
    }
}
