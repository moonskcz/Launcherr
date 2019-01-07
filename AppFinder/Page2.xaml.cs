using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppFinder
{
    /// <summary>
    /// Interakční logika pro Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private Frame frame;
        public Page2()
        {
            InitializeComponent();

        }

        public Page2(Frame frame) : this()
        {
            this.frame = frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;
            var dlg = new FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dlg.ShowDialog(this.GetIWin32Window());
            mainWindow.MainPath = dlg.SelectedPath;
            frame.Navigate(new Page1(frame));
        }
    }
}
