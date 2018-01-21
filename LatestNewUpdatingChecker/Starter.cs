using Microsoft.Win32;

namespace LatestNewUpdatingChecker
{
    static class Starter
    {   
        private const string _autoRunArgument = " / startup";
        private const string _thisProgramName = "LastNewsUpdatingChecker";
        private const string _runSubKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";        
        private static string _thisProgramPath;
        public static string ThisProgramPath
        {
            get { return _thisProgramPath; }
            set
            {
                if (string.IsNullOrEmpty(_thisProgramPath)) _thisProgramPath = value + _autoRunArgument;
            }
        }

        public static bool WithWindows
        {
            get
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(_runSubKey, true);
                return rk.GetValue(_thisProgramName) != null ? true : false;
            }
        }

        public static void SetStartUp(bool set)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(_runSubKey, true);

            if (set)
            {
                if ((rk.GetValue(_thisProgramName) == null))
                {
                    rk.SetValue(_thisProgramName, ThisProgramPath);
                }
            }
            else
                rk.DeleteValue(_thisProgramName, false);
        }        
    }
}
