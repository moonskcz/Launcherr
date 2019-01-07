using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppFinder
{
    /// <summary>
    /// Interakční logika pro Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Frame frame;

        FileWorker FW = new FileWorker();
        List<Project> Projects = new List<Project>();
        int ProjectIndex = 0;

        public Page1()
        {
            InitializeComponent();

            var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

            Projects = FW.GetProjects(mainWindow.MainPath);

            foreach (Project project in Projects)
            {
                lBox.Items.Add(project.Name);
            }
        }

        public Page1(Frame frame) : this()
        {
            this.frame = frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try { Projects[ProjectIndex].Launch(0); }
            catch { lBox3.Content = "App doesnt have a working .exe file."; }
        }

        private void LBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProjectIndex = lBox.SelectedIndex;
            Project currPro = Projects[ProjectIndex];
            lBox1.Content = currPro.Name;
            lBox3.Content = "";
            lBox5.Content = currPro.FolderName;

            try { lBox4.Content = File.GetCreationTime(currPro.Paths[0]); }
            catch { lBox4.Content = "Error"; }
            
            try
            {
                Image img = new Image();
                img.Source = currPro.GetIcon(ProjectIndex).ToImageSource();

                appImage.Source = img.Source;
                lBox2.Content = "";
            }
            catch { lBox2.Content = "App doesnt have an icon"; appImage.Source = null; }

        }
    }
}
