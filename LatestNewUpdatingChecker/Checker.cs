using System;
using System.IO;
using System.Net;
using System.Collections.Generic;


namespace LatestNewUpdatingChecker
{
    class Checker
    {
        private Data objectData;

        public Checker(Data data)
        {
            objectData = data;
        }

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
                    }
                }
                return null;
            }
        }

        public bool CompareIds(string line,string Html_Id)
        {
            if (!string.IsNullOrEmpty(line) && line != objectData.Html_Id)
            {
                Dictionary<string, string> Html_Id_Controller = new Dictionary<string, string>() { {Html_Id,line } };
                objectData.UpdateDataFile(Html_Id_Controller);
                return true;
            }
            return false;
        }        
    }       
}
