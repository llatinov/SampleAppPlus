using ArtOfTest.WebAii.Core;
using AutomationRhapsody.NTestsRunner.Types;
using SampleAppPlus.Tests.Framework.Elements;
using White.Core;

namespace SampleAppPlus.Tests.Framework
{
    public class BaseTest
    {
        protected App App { get; set; }
        private string applicationPath = "C:\\SampleAppPlus\\SampleAppPlus\\bin\\Debug\\SampleAppPlus.exe";

        protected void Start()
        {
            if (App == null)
            {
                Application appWhite = Application.Launch(applicationPath);
                Manager manager = new Manager(false);
                manager.Start();
                App = new App(manager.ConnectToApplication(appWhite.Process), appWhite);
            }
        }

        protected void Stop()
        {
            if (App != null && App.ApplicationWhite != null)
            {
                App.ApplicationWhite.Kill();
            }
            App = null;
        }

        #region Actions
        protected void AttachFile(string path)
        {
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(path);
            App.OpenFile.ClickOpenButton();
            App.MessageBox.ClickOkButton();
        }
        #endregion

        #region Verifications
        public static Verification VerifyText(string expected, string actual)
        {
            if (expected != actual)
            {
                return new VerificationFailed("Texts different. Actual: {0}. Expected: {1}", actual, expected);
            }
            else
            {
                return new VerificationPassed("Texts as expected: {0}", actual);
            }
        }
        #endregion
    }
}
