using Microsoft.Win32;

namespace LatestNewUpdatingChecker
{
    static class Starter
    {
        private const string _thisProgramName = "LastNewsUpdatingChecker";
        private const string _runSubKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public static string ThisProgramPath
        {
            get { return ThisProgramPath; }
            set
            {
                if (string.IsNullOrEmpty(ThisProgramPath)) ThisProgramPath = value;
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
