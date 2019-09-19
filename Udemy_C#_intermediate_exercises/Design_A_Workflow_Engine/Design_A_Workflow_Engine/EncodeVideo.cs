using System;

namespace Design_A_Workflow_Engine
{
    public class EncodeVideo : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Video sent to third party encoding service.");
        }
    }
}
