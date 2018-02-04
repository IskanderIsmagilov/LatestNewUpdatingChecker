using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace LatestNewUpdatingChecker
{
    class Data
    {
        private const string caretReturn =  "\r";
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
                ReadDataFile();
                UpdateProperties();
            }
        }

        private string _dataFilePath;
        private List<string> _lines;
        public string textBoxNewsPage { get; set; }
        public string textBoxEMail { get; set; }
        public string textBoxHtml { get; set; }
        private int _lastIdNum;
        public string textBoxLastId
        {
            get { return ""+_lastIdNum; }
            set
            {                
                bool test = int.TryParse(value, out _lastIdNum);   
            }         
        }
        public string EmailText { get; set; }
        public string NotificationText { get; set; }
        
        public string Html_Id => textBoxHtml + textBoxLastId;

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
                    writer.WriteLine(_lines[i]);
                }
                if (changes.Count != 0)
                {
                    foreach (KeyValuePair<string, string> change in changes)
                    {
                        string newLine = change.Key + ":" + change.Value;
                        _lines.Add(newLine);
                        writer.WriteLine(newLine);
                    }
                }
            }
        }

        public void UpdateDataFile(string key, string value)
        {
            bool found = false;
            using (var writer = new StreamWriter(_dataFilePath, false))
            {
                for (int i = 0; i < _lines.Count; i++)
                {
                    int colon = _lines[i].IndexOf(':');
                    if (colon == -1)
                    {
                        _lines.Remove(_lines[i]);
                        continue;
                    }
                    string keyLine = _lines[i].Substring(0, colon);
                    if (key==keyLine)
                    {
                        _lines[i] = keyLine + ":" + value;
                        found = true;
                    }
                    writer.WriteLine(_lines[i]);
                }
                if (!found)
                {
                    string newLine = key + ":" + value;
                    _lines.Add(newLine);
                    writer.WriteLine(newLine);                    
                }
            }
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

        public void UpdateProperties()
        {            
            for (int i = 0;i<_lines.Count;i++)
            {                
                int colon = _lines[i].IndexOf(':');
                if (colon == -1)
                {
                    _lines.Remove(_lines[i]);
                    continue;
                }
                _lines[i] = _lines[i].Replace(caretReturn, "");
                string key = _lines[i].Substring(0, colon);
                string value = _lines[i].Substring(colon + 1);
                PropertyInfo property = GetType().GetProperty(key);
                if (property == null) _lines.Remove(_lines[i]);
                else property.SetValue(this, value);                
            }           
        }
    }
}
