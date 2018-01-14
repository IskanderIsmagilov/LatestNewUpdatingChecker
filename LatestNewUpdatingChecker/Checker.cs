using System;
using System.IO;
using System.Net;


namespace LatestNewUpdatingChecker
{
    class Checker
    {
        public Checker()
        {}

        public StreamReader GetNewsPageContent(string NewsPageAddres)
        {
            var webClient = new WebClient();
            byte[] newsPage = webClient.DownloadData(NewsPageAddres);

            using (MemoryStream stream = new MemoryStream(newsPage))
            {
                return new StreamReader(stream);
            }          
        }

        public string GetLastNewsId(StreamReader content,string Html_Id)
        {
            using (content)
            {
                string line;
                while ((line = content.ReadLine()) != null)
                {
                    if (line.Contains(Html_Id))
                    {
                        string[] parts = line.Split(new Char[] { '"' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string part in parts)
                        {
                            if (part.Contains(Html_Id))
                            {
                                return part;                                
                            }
                        }
                        break;
                    }
                }
                return null;
            }
        }

        public bool CompareIds(string line,string fileNameLastId,string Html_Id)
        {
            if (!string.IsNullOrEmpty(line) && line != GetLastExistingNewsId(fileNameLastId,Html_Id))
            {
                UpdateLastExistingNewsId(fileNameLastId,line);
                return true;
            }
            return false;
        }

        public static void UpdateLastExistingNewsId(string fileNameLastId, string newsId)
        {
            using (var writer = new StreamWriter(fileNameLastId, false))
            {
                writer.Write(newsId);
            }
        }

        public static string GetLastExistingNewsId(string fileNameLastId, string Html_Id)
        {
            FileInfo file = new FileInfo(fileNameLastId);
            if (file.Exists)
            {
                using (var reader = new StreamReader(fileNameLastId))
                {
                    return reader.ReadLine().Trim();
                }
            }
            UpdateLastExistingNewsId(fileNameLastId, Html_Id);
            return Html_Id;
        }
    }       
}
