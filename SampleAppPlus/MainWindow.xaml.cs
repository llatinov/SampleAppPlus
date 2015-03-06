using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;

namespace SampleAppPlus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Action EmptyDelegate = delegate() { };
        private DataGridView dataGridView;

        public MainWindow()
        {
            InitializeComponent();
            // Initialize host
            myHost = new WindowsFormsHost();
            myHost.Width = 230;
            myHost.Height = 230;
            myHost.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            myHost.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            myHost.Margin = new Thickness(0, 70, 20, 0);
            // Initialize grid
            dataGridView = new DataGridView();
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;
            // Add columnt to grid
            DataGridViewColumn col;
            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.Name = "File Name";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns.Add(col);
            // Add grid to host
            myHost.Child = dataGridView;
            // Add host to window main grid
            mainGrid.Children.Add(myHost);
            // Redraw window
            WindowStyle = WindowStyle.ThreeDBorderWindow;
            // Initialise custom control
            CustomControl.Message = "No file...";
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            Stream checkStream = null;
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "All Image Files | *.*";

            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    if ((checkStream = openFileDialog.OpenFile()) != null)
                    {
                        MyImage.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                        CustomControl.Message = openFileDialog.FileName;
                        dataGridView.Rows.Add(new object[] { openFileDialog.FileName });
                        System.Windows.MessageBox.Show("Successfully done");
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
            else
            {
                System.Windows.MessageBox.Show("Problem occured, try again later");
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddText form = new AddText();
            form.text.Focus();
            bool? result = form.ShowDialog();
            if (result.Value)
            {
                CustomControl.Message = form.text.Text;
                dataGridView.Rows.Add(new object[] { form.text.Text });
                dataGridView.ClearSelection();
            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditText form = new EditText();
            form.text.Focus();
            form.text.Text = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[0].Value as string;
            form.currentText.Text = CustomControl.Message;
            bool? result = form.ShowDialog();
            if (result.Value)
            {
                CustomControl.Message = form.text.Text;
                dataGridView.Rows[dataGridView.CurrentCell.RowIndex].SetValues(form.text.Text);
                dataGridView.ClearSelection();
            }
        }
    }
}
