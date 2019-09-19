namespace Design_A_Workflow_Engine
{
    public class WorkflowEngine
    {
        public WorkflowEngine()
        {

        }

        public void Run(Workflow workflow)
        {
            foreach (var activity in workflow.Activities)
            {
                activity.Execute();
            }
        }
    }
}
