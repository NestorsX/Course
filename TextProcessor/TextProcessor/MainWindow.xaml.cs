using System.Windows;

namespace TextProcessor
{
    public partial class MainWindow : Window
    {
        private FileController _controller;

        public MainWindow()
        {
            InitializeComponent();
            _controller = new FileController();
        }

        private void BtnNewFile_Click(object sender, RoutedEventArgs e)
        {
            workplace.Clear();
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            string? text = _controller.OpenFile();
            if (text != null)
            {
                workplace.Text = text;
            }
        }

        private void BtnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            _controller.SaveFile(workplace.Text);
        }

        private void BtnSaveFileAs_Click(object sender, RoutedEventArgs e)
        {
            _controller.SaveFileAs(workplace.Text);
        }
    }
}
