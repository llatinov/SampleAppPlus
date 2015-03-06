using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SampleAppPlus
{
    /// <summary>
    /// Interaction logic for CustomControl.xaml
    /// </summary>
    public partial class CustomControl : UserControl
    {
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(CustomControl), new PropertyMetadata(OnChange));

        public CustomControl()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            myImage.Source = WriteText(Message); ;
        }

        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as CustomControl;
            current.myImage.Source = WriteText((string)e.NewValue);
        }

        private static RenderTargetBitmap WriteText(string text)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                FormattedText ft = new FormattedText(text ?? string.Empty, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Arial"), 26, Brushes.Blue);
                drawingContext.DrawText(ft, new Point(0, 0));
            }
            RenderTargetBitmap bmp = new RenderTargetBitmap(510, 50, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            return bmp;
        }
    }
}
