using System;

namespace Design_A_Workflow_Engine
{
    public class ChangeStatusOfVideo : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Changed the status of the video record in the database to \"Processing\"");
        }
    }
}
