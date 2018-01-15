using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LatestNewUpdatingChecker
{
    class Data
    {        
        public Data(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
            FileInfo dataFile = new FileInfo(_dataFilePath);
            if (!dataFile.Exists)
            {
                CreateFile(); 
            }
            else
            {
                UpdateProperties();
                ReadDataFile();
            }
        }

        private string _dataFilePath;
        private List<string> _lines;
        public string WebPageText { get; set; }
        public string HtmlTagText { get; set; }
        private int _lastIdNum;
        public string LastIdNum
        {
            get { return ""+_lastIdNum; }
            set { _lastIdNum = int.Parse(value); }
        }
        public string EmailText { get; set; }
        public string NotificationText { get; set; }
        public bool StartWithWindows { get; set; }
        
        public string Html_Id => HtmlTagText + LastIdNum;

        public void ReadDataFile()
        {
            using (var reader = new StreamReader(_dataFilePath))
            {
                string text = reader.ReadToEnd();
                _lines =  new List<string>(text.Split('\n'));
            }
        }

        public string GetLineFromDataFile(string controlName)
        {           
            foreach (string line in _lines)
            {
                if (line.Contains(controlName)) return line;
            }
            return null;
        }

        public void UpdateDataFile(Dictionary<string,string> changes)
        {            
            using (var writer = new StreamWriter(_dataFilePath, false))
            {
                for (int i = 0; i < _lines.Count; i++)
                {
                    int colon = _lines[i].IndexOf(':');
                    string key = _lines[i].Substring(0, colon);
                    if (changes.ContainsKey(key))
                    {
                        _lines[i] = key + ":" + changes[key];
                        changes.Remove(key);
                    }
                    writer.Write(_lines[i]);
                }
                if (changes.Count != 0)
                {
                    foreach (KeyValuePair<string, string> control in changes)
                    {
                        writer.Write(control.Key + ":" + control.Value);
                    }
                }
            }
            ReadDataFile();
        }

        public void UpdateDataFile(string key, string value)
        {
            bool found = false;
            using (var writer = new StreamWriter(_dataFilePath, false))
            {
                for (int i = 0; i < _lines.Count; i++)
                {
                    int colon = _lines[i].IndexOf(':');
                    string keyLine = _lines[i].Substring(0, colon);
                    if (key==keyLine)
                    {
                        _lines[i] = keyLine + ":" + value;
                        found = true;
                    }
                    writer.Write(_lines[i]);
                }
                if (!found)
                {                    
                    writer.Write(key + ":" + value);                    
                }
            }
            ReadDataFile();
        }

        private void CreateFile()
        {
            using (var writer = new StreamWriter(_dataFilePath, false))
            {
                foreach (PropertyInfo prop in GetType().GetProperties())
                {
                    writer.WriteLine(prop.Name + ":");
                }
            }
            ReadDataFile();
        }

        private void UpdateProperties()
        {            
            foreach (string line in _lines)
            {
                int colon = line.IndexOf(':');
                string key = line.Substring(0, colon);
                string value = line.Substring(colon + 1);
                GetType().GetProperty(key).SetValue(this, value);
            }
        }
    }
}
