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

        //SetStartUp(true);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Starter.ThisProgramPath = _thisProgramPath;
            Checker checker = new Checker();
            Data data = new Data(dataFilePath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form mainForm = new Form1(checker, data);

            Application.Run(mainForm);

            while (true)
            {
                if (CheckForNewNews(dataFilePath))
                {
                    Console.WriteLine("На сайте есть новая новость.");
                    Process.Start("http://frgsrb.ru/news/?SECTION_ID=485");
                }
                else
                {
                    TimeSpan forOneHour = new TimeSpan(1, 0, 0);
                    Thread.Sleep(forOneHour);
                }
            }
        }
    }
}
