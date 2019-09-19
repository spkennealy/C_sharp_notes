using System;

namespace Design_A_Workflow_Engine
{
    public class UploadVideo : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Uploading a video to cloud storage.");
        }
    }
}
