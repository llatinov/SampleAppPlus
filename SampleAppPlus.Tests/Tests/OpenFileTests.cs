using AutomationRhapsody.NTestsRunner.Types;
using SampleAppPlus.Tests.Framework;
using System.Collections.Generic;

namespace SampleAppPlus.Tests
{
    [TestClass]
    public class OpenFileTests : BaseTest
    {
        [TestMethod]
        public void Initialise(List<Verification> verifications)
        {
            Start();
        }

        [TestMethod]
        public void MainWindow_NoFilesAttached(List<Verification> verifications)
        {
            verifications.Add(App.MainWindow.VerifyTableHeader(Text.TableHeader));
            verifications.Add(App.MainWindow.VerifyTableItemsCount(0));
            verifications.Add(App.MainWindow.VerifyCustomImageText("No file..."));
        }

        [TestMethod]
        public void OpenFile_OnCancel_GivesMessage(List<Verification> verifications)
        {
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.ClickCancelButton();
            verifications.Add(App.MessageBox.VerifyMessageText(Messages.ProblemOccured));
            App.MessageBox.ClickOkButton();
        }

        [TestMethod]
        public void OpenFile_OnAttachFile_GivesMessageAndFileIsShown(List<Verification> verifications)
        {
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(Constants.FilePath);
            App.OpenFile.ClickOpenButton();
            verifications.Add(App.MessageBox.VerifyMessageText(Messages.Success));
            App.MessageBox.ClickOkButton();
            verifications.Add(App.MainWindow.VerifyTableCell(1, Constants.FilePath));
            verifications.Add(App.MainWindow.VerifyTableItemsCount(1));
            verifications.Add(App.MainWindow.VerifyCustomImageText(Constants.FilePath));
        }

        [TestMethod]
        public void OpenFile_OnAttachSecondFile_GivesMessageAndFilesAreShown(List<Verification> verifications)
        {
            // Attach second file
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(Constants.FilePath);
            App.OpenFile.ClickOpenButton();
            verifications.Add(App.MessageBox.VerifyMessageText(Messages.Success));
            App.MessageBox.ClickOkButton();
            verifications.Add(App.MainWindow.VerifyTableCell(2, Constants.FilePath));
            verifications.Add(App.MainWindow.VerifyTableItemsCount(2));
            verifications.Add(App.MainWindow.VerifyCustomImageText(Constants.FilePath));
        }

        [TestMethod]
        public void CleanUp(List<Verification> verifications)
        {
            Stop();
        }
    }
}
