using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CssSprite
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public Update(string curVersion,VersionInfo newVersion)
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            labelOld.Text = curVersion;
            labelNew.Text = newVersion.Version;
            linkInstr.Text = newVersion.IntroductionUrl;
            linkDownload.Text = newVersion.DownloadUrl;

            linkInstr.Click += linkInstr_Click;

            linkDownload.Click+=linkDownload_Click;
        }

        void linkInstr_Click(object sender, EventArgs e)
        {
            Process.Start(linkInstr.Text);
        }

        void linkDownload_Click(object sender, EventArgs e)
        {
            Process.Start(linkDownload.Text);
        }
        
    }
}
