using ArtOfTest.WebAii.Controls.Xaml.Wpf;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.TestTemplates;
using AutomationRhapsody.NTestsRunner.Types;
using System;
using White.Core;

namespace SampleAppPlus.Tests.Framework.Elements
{
    public class MainWindow : XamlElementContainer
    {
        public static string WINDOW_NAME = "MainWindow";
        private Application app;
        private string mainPath = "XamlPath=/Border[0]/AdornerDecorator[0]/ContentPresenter[0]/Grid[0]/";
        public MainWindow(VisualFind find, Application application)
            : base(find)
        {
            app = application;
        }

        #region Elements
        private Button Button_Browse
        {
            get
            {
                return Get<Button>(mainPath + "Button[0]");
            }
        }

        private Image Image
        {
            get
            {
                return Get<Image>(mainPath + "Image[0]");
            }
        }

        private MainGrid MainGrid
        {
            get
            {
                return new MainGrid(app.GetWindowByName(WINDOW_NAME));
            }
        }

        private UserControl CustomControl_Image
        {
            get
            {
                return Get<UserControl>(mainPath + "CustomControl[0]");
            }
        }

        private Button Button_AddText
        {
            get
            {
                return Get<Button>(mainPath + "Button[1]");
            }
        }

        private Button Button_EditText
        {
            get
            {
                return Get<Button>(mainPath + "Button[2]");
            }
        }
        #endregion

        #region Actions
        public void ClickBrowseButton()
        {
            Button_Browse.User.Click();
        }

        public void ClickAddTextButton()
        {
            Button_AddText.User.Click();
        }

        public void ClickEditTextButton()
        {
            Button_EditText.User.Click();
        }

        public void ClickTableAtRow(int row)
        {
            MainGrid.ClickAtRow(row);
        }
        #endregion

        #region Verifications
        public Verification VerifyTableHeader(Text text)
        {
            return BaseTest.VerifyText(text.GetStringValue(), MainGrid.GetHeaderText());
        }

        public Verification VerifyTableCell(int index, string text)
        {
            return BaseTest.VerifyText(text, MainGrid.GetCellText(index));
        }

        public Verification VerifyTableItemsCount(int count)
        {
            return BaseTest.VerifyText(count.ToString(), MainGrid.GetRowsCount().ToString());
        }

        public Verification VerifyCustomImageText(string expected)
        {
            string actual = CustomControl_Image.GetAttachedProperty<string>("", "Message");
            return BaseTest.VerifyText(expected, actual);
        }
        #endregion
    }
}
