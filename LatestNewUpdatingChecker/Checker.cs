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
            if (!string.IsNullOrEmpty(line) && line != GetLineFromDataFile(dataFilePath,Html_Id))
            {
                Dictionary<string, string> Html_Id_Controller = new Dictionary<string, string>() { {Html_Id,line } };
                UpdateDataFile(dataFilePath, Html_Id_Controller);
                return true;
            }
            return false;
        }

        public void UpdateDataFile(string dataFilePath, Dictionary<string,string> controls)
        {
            List<string> lines = ReadDataFile(dataFilePath);
            using (var writer = new StreamWriter(dataFilePath, false))
            {
                for (int i=0;i<lines.Count;i++)
                {
                    string line = lines[i];
                    int colon = line.IndexOf(':');
                    string key = line.Substring(0, colon);
                    if (controls.ContainsKey(key))
                    {
                        line = key+ ":"+controls[key];                        
                        controls.Remove(key);
                    }
                    writer.Write(line);
                }
                if (controls.Count != 0)
                {
                    foreach (KeyValuePair<string, string> control in controls)
                    {
                        writer.Write(control.Key+":"+control.Value);
                    }
                }
            }            
        }

        public void UpdateDataFile(string dataFilePath, KeyValuePair<string, string> control)
        {
            bool found = false;
            List<string> lines = ReadDataFile(dataFilePath);
            using (var writer = new StreamWriter(dataFilePath, false))
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    string line = lines[i];
                    int colon = line.IndexOf(':');
                    string key = line.Substring(0, colon);
                    if (control.Key == key)
                    {
                        line = key + ":" + control.Key;
                        found = true;
                    }
                    writer.Write(line);
                }
                if (!found)
                {
                    writer.Write(control.Key + ":" + control.Value);
                }
            }
        }

        public void UpdateDataFile(string dataFilePath) // is called if there is no the data file.
        {       
            using (var writer = new StreamWriter(dataFilePath, false))
            {
                foreach (string name in ControlNames)
                {
                    writer.WriteLine(name+":");
                }                               
            }
        }

        public List<string> ReadDataFile(string dataFilePath)
        {
            FileInfo file = new FileInfo(dataFilePath);
            if (file.Exists)
            {
                using (var reader = new StreamReader(dataFilePath))
                {
                    string text = reader.ReadToEnd();
                    return new List<string>(text.Split('\n'));
                }
            }
            UpdateDataFile(dataFilePath);
            return null;
        }

        public string GetLineFromDataFile(string dataFilePath, string controlName)
        {
            List<string> lines = ReadDataFile(dataFilePath);
            foreach (string line in lines)
            {                            
                if (line.Contains(controlName)) return line;
            }
            return null;
        }
    }       
}
