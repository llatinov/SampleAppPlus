using AutomationRhapsody.NTestsRunner.Types;
using SampleAppPlus.Tests.Framework;
using System.Collections.Generic;

namespace SampleAppPlus.Tests
{
    [TestClass]
    public class AddEditTextTests : BaseTest
    {
        [TestMethod]
        public void Initialise(List<Verification> verifications)
        {
            Start();
        }

        [TestMethod]
        public void AddText_WithoutAddingImage_Cancel(List<Verification> verifications)
        {
            verifications.Add(App.MainWindow.VerifyTableItemsCount(0));
            verifications.Add(App.MainWindow.VerifyCustomImageText("No file..."));
            App.MainWindow.ClickAddTextButton();
            App.AddText.EnterText("aaa");
            App.AddText.ClickCancelButton();
            verifications.Add(App.MainWindow.VerifyTableItemsCount(0));
            verifications.Add(App.MainWindow.VerifyCustomImageText("No file..."));
        }

        [TestMethod]
        public void AddText_WithoutAddingImage_OK(List<Verification> verifications)
        {
            string text = "aaa";
            verifications.Add(App.MainWindow.VerifyTableItemsCount(0));
            verifications.Add(App.MainWindow.VerifyCustomImageText("No file..."));
            App.MainWindow.ClickAddTextButton();
            App.AddText.EnterText(text);
            App.AddText.ClickSaveButton();
            verifications.Add(App.MainWindow.VerifyTableItemsCount(1));
            verifications.Add(App.MainWindow.VerifyTableCell(1, text));
            verifications.Add(App.MainWindow.VerifyCustomImageText(text));
        }

        [TestMethod]
        public void EditText_WithoutAddingImage_Cancel(List<Verification> verifications)
        {
            string text = "aaa";
            App.MainWindow.ClickEditTextButton();
            App.EditText.EnterText("bbb");
            App.EditText.ClickCancelButton();
            verifications.Add(App.MainWindow.VerifyTableCell(1, text));
            verifications.Add(App.MainWindow.VerifyCustomImageText(text));
        }

        [TestMethod]
        public void EditText_WithoutAddingImage_OK(List<Verification> verifications)
        {
            string text = "bbb";
            App.MainWindow.ClickEditTextButton();
            App.EditText.EnterText(text);
            App.EditText.ClickSaveButton();
            verifications.Add(App.MainWindow.VerifyTableItemsCount(1));
            verifications.Add(App.MainWindow.VerifyTableCell(1, text));
            verifications.Add(App.MainWindow.VerifyCustomImageText(text));
        }

        [TestMethod]
        public void EditText_AfterAddingImage(List<Verification> verifications)
        {
            // Break test dependencies
            Stop();
            Start();
            string text = "ccc";
            // Add images
            AttachFile(Constants.FilePath);
            AttachFile(Constants.FilePath);
            verifications.Add(App.MainWindow.VerifyTableItemsCount(2));
            verifications.Add(App.MainWindow.VerifyTableCell(1, Constants.FilePath));
            verifications.Add(App.MainWindow.VerifyTableCell(2, Constants.FilePath));
            verifications.Add(App.MainWindow.VerifyCustomImageText(Constants.FilePath));
            // Edit
            App.MainWindow.ClickTableAtRow(2);
            App.MainWindow.ClickEditTextButton();
            verifications.Add(App.EditText.VerifyCurrentText(Constants.FilePath));
            App.EditText.EnterText(text);
            App.EditText.ClickSaveButton();
            verifications.Add(App.MainWindow.VerifyTableItemsCount(2));
            verifications.Add(App.MainWindow.VerifyTableCell(1, Constants.FilePath));
            verifications.Add(App.MainWindow.VerifyTableCell(2, text));
            verifications.Add(App.MainWindow.VerifyCustomImageText(text));
        }

        [TestMethod]
        public void AddText_AfterAddingImage(List<Verification> verifications)
        {
            string text = "ddd";
            App.MainWindow.ClickAddTextButton();
            App.AddText.EnterText(text);
            App.AddText.ClickSaveButton();
            verifications.Add(App.MainWindow.VerifyTableCell(1, Constants.FilePath));
            verifications.Add(App.MainWindow.VerifyTableCell(2, "ccc"));
            verifications.Add(App.MainWindow.VerifyTableCell(3, text));
        }

        [TestMethod]
        public void CleanUp(List<Verification> verifications)
        {
            Stop();
        }
    }
}
