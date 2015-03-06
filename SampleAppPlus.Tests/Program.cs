using AutomationRhapsody.NTestsRunner;

namespace SampleAppPlus.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            NTestsRunner runner = new NTestsRunner();
            runner.TestResultsDir = @"C:\temp";
            runner.MaxTestCaseRuntimeMinutes = 2;
            runner.TestsToExecute.Add("AddEditTextTests");
            runner.Execute();
        }
    }
}
