using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LatestNewUpdatingChecker
{
    class Checker
    {
        private Data objectData;

        public Checker(Data data)
        {
            objectData = data;
        }

        public MemoryStream GetNewsPageContent()
        {
            var webClient = new WebClient();
            byte[] newsPage = webClient.DownloadData(objectData.textBoxNewsPage);
            
            return new MemoryStream(newsPage);            
        }

        public string GetLastNewsId(MemoryStream content)
        {
            using (content)
            using (StreamReader contentReader = new StreamReader(content))
            {
                string line;
                while ((line = contentReader.ReadLine()) != null)
                {
                    if (line.Contains(objectData.textBoxHtml)) //textBoxHtml
                    {
                        string[] parts = line.Split(new Char[] { '"' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string part in parts)
                        {
                            if (part.Contains(objectData.textBoxHtml))
                            {
                                return part;
                            }
                        }
                    }
                }
                return null;
            }
        }

        public bool CompareIds(string line)
        {
            if (!string.IsNullOrEmpty(line) && line != objectData.Html_Id)
            {
                string newId = line.Replace(objectData.textBoxHtml, "");                
                objectData.UpdateDataFile(nameof(objectData.textBoxLastId),newId);
                objectData.UpdateProperties();                
                return true;
            }
            return false;
        }

        public async Task<bool> CheckForNewNews()
        {
            MemoryStream content = GetNewsPageContent();
            string Found_Html_Id = GetLastNewsId(content);
            bool gotNew = CompareIds(Found_Html_Id);           
            if (!gotNew)
            {
                TimeSpan forOneHour = new TimeSpan(0, 45, 0);
                await Task.Delay(forOneHour);
            }
            return gotNew;
        }
    }
}
