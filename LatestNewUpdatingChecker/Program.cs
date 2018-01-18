using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace LatestNewUpdatingChecker
{
    static class Program
    {
        private const string _dataFileName = "Data.txt";        
        private const string _newsPageContentFileName = "NewsPageContent.txt";          

        private static string _thisProgramPath => Assembly.GetEntryAssembly().Location;        
        static string currentDirectory = Path.GetDirectoryName(_thisProgramPath);
        static string dataFilePath = Path.Combine(currentDirectory, _dataFileName);

        [STAThread]
        static void Main()
        {
            Starter.ThisProgramPath = _thisProgramPath;
            Data data = new Data(dataFilePath);
            Checker checker = new Checker(data);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form mainForm = new Form1(checker, data);

            Application.Run(mainForm);
        }
    }
}
