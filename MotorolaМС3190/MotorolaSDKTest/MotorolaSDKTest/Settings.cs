using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ASRKclient
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.textBox1.Text = Setting.ServiceUrl;// ChoseOperation.IP;
            this.textBox3.Text = Setting.TimeOut;//" value="10000" /> ChoseOperation.TIMEOUT.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Setting.ServiceUrl = this.textBox1.Text;
                Setting.TimeOut = this.textBox3.Text;                
                Convert.ToInt32(this.textBox3.Text);
                Setting.Update();
                this.Dispose(); //this.Close();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Невірний формат числа. Ввести число ще раз?", ex.Message, MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                }
                else 
                {
                    this.Dispose(); 
                    //this.Close();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();

            myProcess.StartInfo.FileName = "\\Windows\\WCConfigEd.exe";// @"\Windows\ctlpnl.exe";// @"\applications\scanwedge.exe";// @"\Windows\ctlpnl.exe";//scanwedge.exe, applications folder
           // myProcess.StartInfo.Arguments = "cplmain.cpl, 17, 0";

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