using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatestNewUpdatingChecker
{
    partial class Form1 : Form
    {
        private NotifyIcon _trayIcon;
        private readonly Data _objectData;
        private readonly Checker _checker;

        public Form1(Checker checker,Data data)
        {
            _trayIcon = new NotifyIcon();
            InitializeComponent();

            _checker = checker;
            _objectData = data;
            PropertyInfo[] objectDataProps = _objectData.GetType().GetProperties();
            foreach (PropertyInfo prop in objectDataProps)
            {
                Control[] control = Controls.Find(prop.Name, false);
                if (control.Length > 0)
                {
                    control[0].Text = prop.GetValue(_objectData)?.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNewsPage_TextChanged(object sender, EventArgs e)
        {            
            string webPageText;
            webPageText = textBoxNewsPage.Text;                      
            _objectData.textBoxNewsPage = webPageText;          
            _objectData.UpdateDataFile(nameof(_objectData.textBoxNewsPage), webPageText);

        }

        private void textBoxHtml_TextChanged(object sender, EventArgs e)
        {
            string htmlTagText;
            htmlTagText = textBoxHtml.Text;           
            _objectData.textBoxHtml = htmlTagText;
            _objectData.UpdateDataFile(nameof(_objectData.textBoxHtml), htmlTagText);
        }
       
        private void textBoxLastId_TextChanged(object sender, EventArgs e)
        {
            string lastIdText;
            lastIdText = textBoxLastId.Text;
            if (!int.TryParse(lastIdText, out int lastIdNum))
            {
                textBoxNotes.Text = "Id you is not a num, please enter a number";
                return;
            }            
            _objectData.textBoxLastId = lastIdText;
            _objectData.UpdateDataFile(nameof(_objectData.textBoxLastId), lastIdText);
        }       

        private void checkBoxStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            bool start = checkBoxStartWithWindows.Checked;
            Starter.SetStartUp(start);
        }

        private void toolTipHtml_Popup(object sender, PopupEventArgs e)
        {
            //toolTipHtml.SetToolTip(textBoxHtml, "HTML tag that keeps ID number of news.");
        }

        private async void checkBoxIsChecking_CheckedChanged(object sender, EventArgs e)
        {
            while (checkBoxIsChecking.Checked)
            {
                Task<bool> checking = _checker.CheckForNewNews();
                bool gotNew = await checking;
                if (gotNew) UpdateNotification();
            }
        }

        private void UpdateNotification()
        {            
            textBoxLastId.Text = _objectData.textBoxLastId;
            textBoxNotes.Text = $"Last news is gotten: {DateTime.Now}";
            notifyIcon_Click(null, null);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();                
            }          
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;
        }
    }
}
