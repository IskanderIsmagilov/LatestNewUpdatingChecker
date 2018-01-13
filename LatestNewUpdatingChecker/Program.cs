using Microsoft.Win32;
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
        private const string dataFileName = "Data.txt";
        private const string _newsPageContentFileName = "NewsPageContent.txt";

        private static string thisProgramPath => Assembly.GetEntryAssembly().Location;        
        static string currentDirectory = Path.GetDirectoryName(thisProgramPath);
        static string dataFilePath = Path.Combine(currentDirectory, dataFileName);

        //SetStartUp(true);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Checker checker = new Checker();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form mainForm = new Form1(checker);
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

        //private static void SetStartUp(bool set)
        //{
        //    RegistryKey rk = Registry.CurrentUser.OpenSubKey
        //    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        //    if (set)
        //    {
        //        if ((rk.GetValue("TheApartmentsSellingNews") == null))
        //        {
        //            rk.SetValue("TheApartmentsSellingNews", thisProgramLocation);
        //        }
        //    }
        //    else
        //        rk.DeleteValue("TheApartmentsSellingNews", false);
        //}
    }
}
