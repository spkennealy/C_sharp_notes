using System;

namespace Design_A_Workflow_Engine
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var workflowEngine = new WorkflowEngine();
            var workflow = new Workflow();
            workflow.Add(new UploadVideo());
            workflow.Add(new EncodeVideo());
            workflow.Add(new NotificationEmail());
            workflow.Add(new ChangeStatusOfVideo());
            workflowEngine.Run(workflow);
        }
    }
}
