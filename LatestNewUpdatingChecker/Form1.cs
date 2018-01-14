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
        public string WebPageText { get; set; }
        public string HtmlTagText { get; set; }
        public string LastIdText { get; set; }      
        public string EmailText { get; set; }
        public string NotificationText { get; set; }

        public string Html_Id => HtmlTagText + LastIdText;
        private readonly Checker _checker;

        public Form1(Checker checker)
        {
            _checker = checker;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNewsPage_TextChanged(object sender, EventArgs e)
        {
            WebPageText = textBoxNewsPage.Text;
            if (WebPageText.Substring(WebPageText.Length - 1) != "/") WebPageText += "/";

        }

        private void textBoxHtml_TextChanged(object sender, EventArgs e)
        {
            HtmlTagText = textBoxHtml.Text;
            if (HtmlTagText.Substring(HtmlTagText.Length - 1) != "/") HtmlTagText += "/";
        }
       
        private void textBoxLastId_TextChanged(object sender, EventArgs e)
        {
            LastIdText = textBoxLastId.Text;
            if (LastIdText.Substring(LastIdText.Length - 1) != "/") LastIdText += "/";
        }       

        private void checkBoxStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            Starter.SetStartUp(checkBoxStartWithWindows.Checked);
        }

        private void toolTipHtml_Popup(object sender, PopupEventArgs e)
        {
            //toolTipHtml.SetToolTip(textBoxHtml, "HTML tag that keeps ID number of news.");
        }
    }
}
