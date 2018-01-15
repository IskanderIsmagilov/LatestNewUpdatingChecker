using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatestNewUpdatingChecker
{
    partial class Form1 : Form
    {
        private readonly Data _objectData;
        //private readonly Checker _checker;

        public Form1(Checker checker,Data data)
        {
            _checker = checker;
            _objectData = data;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNewsPage_TextChanged(object sender, EventArgs e)
        {
            string webPageText;
            webPageText = textBoxNewsPage.Text;            
            if (webPageText.Substring(webPageText.Length - 1) != "/") webPageText += "/";
            _objectData.WebPageText = webPageText;           
            _objectData.UpdateDataFile("WebPageText", webPageText);

        }

        private void textBoxHtml_TextChanged(object sender, EventArgs e)
        {
            string htmlTagText;
            htmlTagText = textBoxHtml.Text;
            if (htmlTagText.Substring(htmlTagText.Length - 1) != "/") htmlTagText += "/";
            _objectData.HtmlTagText = htmlTagText;
            _objectData.UpdateDataFile("HtmlTagText", htmlTagText);
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
            lastIdText += "/";
            _objectData.LastIdNum = lastIdText;
            _objectData.UpdateDataFile("LastIdNum", lastIdText);
        }       

        private void checkBoxStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            bool start = checkBoxStartWithWindows.Checked;
            Starter.SetStartUp(start);
            _objectData.StartWithWindows = start;
            _objectData.UpdateDataFile("StartWithWindows", ""+start);
        }

        private void toolTipHtml_Popup(object sender, PopupEventArgs e)
        {
            //toolTipHtml.SetToolTip(textBoxHtml, "HTML tag that keeps ID number of news.");
        }
    }
}
