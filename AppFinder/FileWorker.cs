using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinder
{
    class FileWorker
    {

        //c:\users\jakub\source\repos\
        


        public string GetReposPath ()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }

            return path + @"\source\repos\";
        }

        public List<Project> GetProjects()
        {
            string path = GetReposPath();

            List<string> SL = new List<string>();
            List<Project> PL = new List<Project>();

            var temp = Directory.GetFiles(path, "*.sln", SearchOption.AllDirectories);

            foreach (string projectPath in temp)
            {
                string[] split = projectPath.Split('\\');
                string[] projectName = split[split.Length - 1].Split('.');
                SL.Add(projectName[0]);
            }

            foreach (string projectIndividualName in SL)
            {

                var tmp = Directory.GetFiles(path, projectIndividualName + ".exe", SearchOption.AllDirectories);
                if (tmp.Length == 0)
                {
                    tmp = Directory.GetFiles(path, projectIndividualName + ".*.exe", SearchOption.AllDirectories);
                }

                PL.Add(new Project(tmp, projectIndividualName, "tmp"));

            }

            return PL;
        }

        public List<Project> GetProjects(string path)
        {

            List<string> SL = new List<string>();
            List<Project> PL = new List<Project>();

            var temp = Directory.GetFiles(path, "*.sln", SearchOption.AllDirectories);

            foreach (string projectPath in temp)
            {
                string[] split = projectPath.Split('\\');
                string[] projectName = split[split.Length - 1].Split('.');
                SL.Add(projectName[0]);
            }
            int x = 0;
            foreach (string projectIndividualEXEName in SL)
            {

                var tmp = Directory.GetFiles(path, projectIndividualEXEName + ".exe", SearchOption.AllDirectories);
                if (tmp.Length == 0)
                {
                    tmp = Directory.GetFiles(path, projectIndividualEXEName + ".*.exe", SearchOption.AllDirectories);
                }

                var ttmp = path.Split('\\');
                var tttmp = temp[x].Split('\\');
                string folderName = tttmp[ttmp.Length];

                PL.Add(new Project(tmp, projectIndividualEXEName, folderName));
                x++;
            }

            return PL;
        }

    }
}
