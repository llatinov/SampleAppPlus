using ArtOfTest.WebAii.Controls.Xaml.Wpf;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.TestTemplates;
using System.Threading;

namespace SampleAppPlus.Tests.Framework.Elements
{
    public abstract class AddEditText : XamlElementContainer
    {
        protected string mainPath = "XamlPath=/Border[0]/AdornerDecorator[0]/ContentPresenter[0]/Grid[0]/";
        public AddEditText(VisualFind find) : base(find) { }

        #region Elements
        protected abstract TextBox TextBox_Text { get; }
        private Button Button_Save
        {
            get
            {
                return Get<Button>(mainPath + "Button[0]");
            }
        }
        private Button Button_Cancel
        {
            get
            {
                return Get<Button>(mainPath + "Button[1]");
            }
        }
        #endregion

        #region Actions
        public void EnterText(string text)
        {
            TextBox_Text.Clear();
            TextBox_Text.User.TypeText(text, 50);
        }

        public void ClickSaveButton()
        {
            Button_Save.User.Click();
            Thread.Sleep(500);
        }

        public void ClickCancelButton()
        {
            Button_Cancel.User.Click();
        }
        #endregion
    }
}
