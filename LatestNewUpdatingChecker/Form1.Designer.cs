namespace LatestNewUpdatingChecker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolTip toolTipHtml;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNewsPage = new System.Windows.Forms.TextBox();
            this.textBoxHtml = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLastId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxStartWithWindows = new System.Windows.Forms.CheckBox();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxIsChecking = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            toolTipHtml = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // toolTipHtml
            // 
            toolTipHtml.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipHtml_Popup);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "News web page:";
            // 
            // textBoxNewsPage
            // 
            this.textBoxNewsPage.Location = new System.Drawing.Point(197, 22);
            this.textBoxNewsPage.Name = "textBoxNewsPage";
            this.textBoxNewsPage.Size = new System.Drawing.Size(440, 22);
            this.textBoxNewsPage.TabIndex = 1;
            this.textBoxNewsPage.TextChanged += new System.EventHandler(this.textBoxNewsPage_TextChanged);
            // 
            // textBoxHtml
            // 
            this.textBoxHtml.Location = new System.Drawing.Point(197, 51);
            this.textBoxHtml.Name = "textBoxHtml";
            this.textBoxHtml.Size = new System.Drawing.Size(440, 22);
            this.textBoxHtml.TabIndex = 3;
            this.textBoxHtml.TextChanged += new System.EventHandler(this.textBoxHtml_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "HTML tag:";
            // 
            // textBoxLastId
            // 
            this.textBoxLastId.Location = new System.Drawing.Point(197, 80);
            this.textBoxLastId.Name = "textBoxLastId";
            this.textBoxLastId.Size = new System.Drawing.Size(440, 22);
            this.textBoxLastId.TabIndex = 5;
            this.textBoxLastId.TextChanged += new System.EventHandler(this.textBoxLastId_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last id:";
            // 
            // textBoxEMail
            // 
            this.textBoxEMail.Location = new System.Drawing.Point(197, 112);
            this.textBoxEMail.Name = "textBoxEMail";
            this.textBoxEMail.Size = new System.Drawing.Size(440, 22);
            this.textBoxEMail.TabIndex = 7;
            this.textBoxEMail.TextChanged += new System.EventHandler(this.textBoxEMail_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "E-mail:";
            // 
            // checkBoxStartWithWindows
            // 
            this.checkBoxStartWithWindows.AutoSize = true;
            this.checkBoxStartWithWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxStartWithWindows.Location = new System.Drawing.Point(659, 24);
            this.checkBoxStartWithWindows.Name = "checkBoxStartWithWindows";
            this.checkBoxStartWithWindows.Size = new System.Drawing.Size(234, 33);
            this.checkBoxStartWithWindows.TabIndex = 10;
            this.checkBoxStartWithWindows.Text = "Start with windows";
            this.checkBoxStartWithWindows.UseVisualStyleBackColor = true;
            this.checkBoxStartWithWindows.CheckedChanged += new System.EventHandler(this.checkBoxStartWithWindows_CheckedChanged);
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(197, 141);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(440, 183);
            this.textBoxNotes.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Notification:";
            // 
            // checkBoxIsChecking
            // 
            this.checkBoxIsChecking.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxIsChecking.AutoSize = true;
            this.checkBoxIsChecking.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxIsChecking.Location = new System.Drawing.Point(813, 285);
            this.checkBoxIsChecking.Name = "checkBoxIsChecking";
            this.checkBoxIsChecking.Size = new System.Drawing.Size(174, 39);
            this.checkBoxIsChecking.TabIndex = 13;
            this.checkBoxIsChecking.Text = "Start checking";
            this.checkBoxIsChecking.UseVisualStyleBackColor = true;
            this.checkBoxIsChecking.CheckedChanged += new System.EventHandler(this.checkBoxIsChecking_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 350);
            this.Controls.Add(this.checkBoxIsChecking);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxStartWithWindows);
            this.Controls.Add(this.textBoxEMail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxLastId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxHtml);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewsPage);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_Resize);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNewsPage;
        private System.Windows.Forms.TextBox textBoxHtml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLastId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxStartWithWindows;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxIsChecking;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

