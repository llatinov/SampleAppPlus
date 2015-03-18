using AutomationRhapsody.NTestsRunner;

namespace SampleAppPlus.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            NTestsRunnerSettings settings = new NTestsRunnerSettings();
            settings.TestResultsDir = @"C:\temp";
            settings.MaxTestCaseRuntimeMinutes = 2;
            settings.TestsToExecute.Add("AddEditTextTests");
            settings.PreventScreenLock = true;

            NTestsRunner runner = new NTestsRunner(settings);
            runner.Execute();
        }
    }
}
