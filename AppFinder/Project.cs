using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AppFinder
{
    class Project
    {

        public List<string> Paths = new List<string>();
        public string Name;
        public string FolderName;

        public Project (List<string> list, string name, string folderName)
        {
            Name = name;
            Paths = list;
            FolderName = folderName;
            ListCleanup();
        }

        public Project (string path, string name, string folderName)
        {
            FolderName = folderName;
            Name = name;
            Paths.Add(path);
        }

        public Project (string[] paths, string name, string folderName)
        {
            FolderName = folderName;
            Name = name;
            foreach (string path in paths)
            {
                Paths.Add(path);
            }
            ListCleanup();
        }

        public void ListCleanup ()
        {
            List<string> SL = new List<string>();

            foreach (string path in Paths)
            {
                if (!path.Contains("//obj//"))
                {
                    SL.Add(path);
                }
            }

            Paths = SL;
        }

        public Icon GetIcon (int index)
        {
            return Icon.ExtractAssociatedIcon(Paths[index]);
        }

        public void Launch (int index)
        {
            System.Diagnostics.Process.Start(Paths[index]);
        }

    }
}
