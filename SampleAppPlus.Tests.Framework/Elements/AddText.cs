using ArtOfTest.WebAii.Controls.Xaml.Wpf;
using ArtOfTest.WebAii.Silverlight;

namespace SampleAppPlus.Tests.Framework.Elements
{
    public class AddText : AddEditText
    {
        public static string WINDOW_NAME = "Add Text";
        public AddText(VisualFind find) : base(find) { }

        protected override TextBox TextBox_Text
        {
            get
            {
                return Get<TextBox>(mainPath + "TextBox[0]");
            }
        }
    }
}
