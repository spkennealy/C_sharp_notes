using System;

namespace Design_A_Workflow_Engine
{
    public class NotificationEmail : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Emailing owner that video is processing.");
        }
    }
}
