using ArtOfTest.WebAii.Controls.Xaml.Wpf;
using ArtOfTest.WebAii.Silverlight;
using AutomationRhapsody.NTestsRunner.Types;

namespace SampleAppPlus.Tests.Framework.Elements
{
    public class EditText : AddEditText
    {
        public static string WINDOW_NAME = "Edit Text";
        public EditText(VisualFind find) : base(find) { }

        #region Elements
        private TextBlock TextBlock_CurrentText
        {
            get
            {
                return Get<TextBlock>(mainPath + "TextBlock[0]");
            }
        }

        protected override TextBox TextBox_Text
        {
            get
            {
                return Get<TextBox>(mainPath + "TextBox[1]");
            }
        }
        #endregion

        #region Verifications
        public Verification VerifyCurrentText(string text)
        {
            return BaseTest.VerifyText(text, TextBlock_CurrentText.Text);
        }
        #endregion
    }
}
