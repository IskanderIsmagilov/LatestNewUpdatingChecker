using System;
using System.IO;
using System.Net;
using System.Collections.Generic;


namespace LatestNewUpdatingChecker
{
    class Checker
    {      
        public string[] ControlNames
        {
            get { return ControlNames; }
            set { if (ControlNames == null) ControlNames = value; }
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

        public bool CompareIds(string line,string dataFilePath,string Html_Id)
        {
            if (!string.IsNullOrEmpty(line) && line != GetLastExistingNewsId(dataFilePath,Html_Id))
            {
                UpdateDataFile(dataFilePath,line);
                return true;
            }
            return false;
        }

        public void UpdateDataFile(string dataFilePath, Dictionary<int,string> lines)
        {          
            using (var reader = new StreamReader(dataFilePath))
            using (var writer = new StreamWriter(dataFilePath, false))
            {
                int i = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(lines.ContainsKey(i) ? lines[i] : line);
                    i++;
                }
            }
        }

        public void UpdateDataFile(string dataFilePath) // is called if there is no the data file.
        {       
            using (var writer = new StreamWriter(dataFilePath, false))
            {
                for (int i = 0; i < _dataFileLineNumbers; i++)
                {
                    writer.WriteLine(i);
                }                               
            }
        }

        public string GetLineFromDataFile(string dataFilePath, int lineNum)
        {
            FileInfo file = new FileInfo(dataFilePath);
            if (file.Exists)
            {
                using (var reader = new StreamReader(dataFilePath))
                {
                    int i = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (i == lineNum) return line;
                        i++;
                    }                                     
                }
            }
            UpdateDataFile(dataFilePath);
            return null;
        }
    }       
}
