using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;

namespace LatestNewUpdatingChecker
{
    class Checker
    {
        public Checker()
        {

        }
        private static string Executable => Assembly.GetEntryAssembly().Location;
        SetStartUp(true);
        string currentDirectory = Path.GetDirectoryName(Executable);
        string fileName = Path.Combine(currentDirectory, "LastNewsId.txt");
        Console.WriteLine(@"File path: {0}.", fileName);
        while (true)
        {
            if (CheckForNewNews(fileName))
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

    public static bool CheckForNewNews(string fileName)
    {
        var webClient = new WebClient();
        byte[] googleHome = webClient.DownloadData("http://frgsrb.ru/news/?SECTION_ID=485");

        using (MemoryStream stream = new MemoryStream(googleHome))
        using (var reader = new StreamReader(stream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("/news/?ELEMENT_ID="))
                {
                    string[] parts = line.Split(new Char[] { '"' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string part in parts)
                    {
                        if (part.Contains("/news/?ELEMENT_ID="))
                        {
                            line = part;
                            break;
                        }
                    }
                    break;
                }
            }
            if (!string.IsNullOrEmpty(line) && line != GetLastExistingNewsId(fileName))
            {
                UpdateLastExistingNewsId(fileName, line);
                return true;
            }
            return false;
        }
    }

    public static void UpdateLastExistingNewsId(string fileName, string newsId)
    {
        using (var writer = new StreamWriter(fileName, false))
        {
            writer.Write(newsId);
        }
    }

    public static string GetLastExistingNewsId(string fileName)
    {
        FileInfo file = new FileInfo(fileName);
        if (file.Exists)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadLine().Trim();
            }
        }
        UpdateLastExistingNewsId(fileName, "/news/?ELEMENT_ID=14718");
        return "/news/?ELEMENT_ID=14718";
    }
    private static void SetStartUp(bool set)
    {
        RegistryKey rk = Registry.CurrentUser.OpenSubKey
        ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        if (set)
        {
            if ((rk.GetValue("TheApartmentsSellingNews") == null))
            {
                rk.SetValue("TheApartmentsSellingNews", Executable);
            }
        }
        else
            rk.DeleteValue("TheApartmentsSellingNews", false);
    }
}
