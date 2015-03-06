using ArtOfTest.WebAii.Wpf;
using White.Core;

namespace SampleAppPlus.Tests.Framework.Elements
{
    public class App
    {
        public WpfApplication ApplicationWebAii { get; private set; }
        public Application ApplicationWhite { get; private set; }

        public App(WpfApplication webAiiApp, Application whiteApp)
        {
            ApplicationWebAii = webAiiApp;
            ApplicationWhite = whiteApp;
        }

        public MainWindow MainWindow
        {
            get
            {
                return new MainWindow(ApplicationWebAii.WaitForWindow(MainWindow.WINDOW_NAME, 5000).Find, ApplicationWhite);
            }
        }

        public AddText AddText
        {
            get
            {
                return new AddText(ApplicationWebAii.WaitForWindow(AddText.WINDOW_NAME, 5000).Find);
            }
        }

        public EditText EditText
        {
            get
            {
                return new EditText(ApplicationWebAii.WaitForWindow(EditText.WINDOW_NAME, 5000).Find);
            }
        }

        public OpenFile OpenFile
        {
            get
            {
                return new OpenFile(ApplicationWhite.GetWindowByName("Open"));
            }
        }

        public MessageBox MessageBox
        {
            get
            {
                return new MessageBox(ApplicationWhite.GetWindowByName(""));
            }
        }
    }
}
