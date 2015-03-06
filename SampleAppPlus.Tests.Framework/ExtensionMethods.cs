using ArtOfTest.WebAii.Silverlight;
using White.Core;
using White.Core.UIItems.WindowItems;
using Keys = System.Windows.Forms.Keys;

namespace SampleAppPlus.Tests.Framework
{
    public static class ExtensionMethods
    {
        public static Window GetWindowByName(this Application appWhite, string windowName)
        {
            foreach (Window window in appWhite.GetWindows())
            {
                if (windowName.Equals(window.Name))
                {
                    return window;
                }
            }
            return null;
        }

        public static void Clear(this FrameworkElement element)
        {
            element.User.Click();
            element.User.KeyPress(Keys.End, 0);
            element.User.KeyDown(Keys.Shift);
            element.User.KeyPress(Keys.Home, 0);
            element.User.KeyUp(Keys.Shift);
            element.User.KeyPress(Keys.Back, 0);
        }
    }
}
