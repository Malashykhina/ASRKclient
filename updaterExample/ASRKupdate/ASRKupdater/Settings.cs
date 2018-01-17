using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ASRKupdator
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.textBox1.Text = Form1.Url;
            //this.textBox2.Text = Form1.SourceDir;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Url = this.textBox1.Text.Trim();
            //Form1.SourceDir = this.textBox2.Text.Trim();
            this.Close();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Process myProcess = new Process();

            myProcess.StartInfo.FileName = @"\Windows\ctlpnl.exe";// @"\Program files\SettingLaunch\SettingsUI.exe";
            //myProcess.StartInfo.Arguments = "cplmain.cpl,8";
            //myProcess.StartInfo.Arguments = "cplmain.cpl, 8, 7, 3";

            myProcess.StartInfo.Arguments = "cplmain.cpl, 17, 0";

            //myProcess.StartInfo.Arguments = "cplmain.cpl,1";
            //myProcess.StartInfo.FileName = @"\Windows\ctlpnl.exe";
            //myProcess.StartInfo.Arguments = "cplmain.cpl,8";
            try
            {
                myProcess.Start();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
            }
        }
    }
}